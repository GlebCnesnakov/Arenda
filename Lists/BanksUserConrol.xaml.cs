using Lists;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Banks
{
    /// <summary>
    /// Логика взаимодействия для BanksUserConrol.xaml
    /// </summary>
    public partial class BanksUserConrol : UserControl
    {
        protected bool[] permissions = new bool[4];
        public BanksUserConrol()
        {
            InitializeComponent();
            //проверка на разрешения
            UserPermissionsVerifier uv = new();
            permissions = uv.VerifyUser(); // Получили разрешения
            dataGrid.CanUserAddRows = false; // не добавлять
            dataGrid.IsReadOnly = true; // не изменять
            dataGrid.CanUserDeleteRows = false;// не удалять
            searchButton.IsEnabled = true;
            if (permissions[0])
            {
                FillDataGrid();
                
            }
            if (permissions[1])
            {
                writeButton.IsEnabled = true;
                writeButton.Visibility = Visibility.Visible;
            }
            if (permissions[2])
            {
                
                editButton.IsEnabled = true;
                editButton.Visibility = Visibility.Visible;
            }
            if (permissions[3])
            {
                deleteButton.IsEnabled = true;
                deleteButton.Visibility = Visibility.Visible;
            }
            // Возможно реализовать WED в самой DataGrid 
        }
        protected void FillDataGrid()
        {
            dataGrid.ItemsSource = Data.ReadData<Bank>();
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            string name = inputTextBox.Text;
            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                MessageBox.Show("Введите элемент для добавления");
                return;
            }
            Data.WriteData<Bank>(name);
            if (permissions[0]) FillDataGrid(); // если можно читать - обновляем таблицу
            if (!permissions[0]) MessageBox.Show("Элемент добавлен");    
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e) // выделяем элемент, пишем в текстбок, меняем
        {
            Bank b = dataGrid.SelectedItem as Bank; // добавить поиск
            string newName = inputTextBox.Text;

            if (b == null || String.IsNullOrEmpty(newName) || newName.Length < 2)
            {
                MessageBox.Show("Старый элемент не выбран или длина нового элемента меньше двух");
                return;
            }
            Data.EditData<Bank>(b.Name, newName);
            if (permissions[0]) FillDataGrid(); // если можно читать - обновляем таблицу
            if (!permissions[0]) MessageBox.Show("Элемент изменён");
        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Осуществить удаление по строке?\nВ случае ответа \"Нет\" будет осуществлено удаление по выбранному элементу",
                "Выбор",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
                );
            if (result == MessageBoxResult.No)
            {
                Bank b = dataGrid.SelectedItem as Bank;
                if (b != null)
                {
                    Data.DeleteData<Bank>(b.Name);
                    if (permissions[0]) FillDataGrid();
                }
            }
            else if (result == MessageBoxResult.Yes)
            {
                string toDelete = inputTextBox.Text;
                if (!String.IsNullOrEmpty(toDelete))
                {
                    Data.DeleteData<Bank>(toDelete);
                    if (permissions[0]) FillDataGrid();
                }
                else
                {
                    MessageBox.Show("Введите элемент для удаления или выберите его");
                }
            }
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string search = searchTextBox.Text;
            if (!String.IsNullOrEmpty(search))
            {
                dataGrid.ItemsSource = Data.SearchData<Bank>(search);
            }
            else
            {
                MessageBox.Show("Введите элемент поиска");
            }
        }
    }
}
