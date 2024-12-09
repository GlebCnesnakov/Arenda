using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Lists
{
    /// <summary>
    /// Логика взаимодействия для StreetsUserControl.xaml
    /// </summary>
    public partial class StreetsUserControl : UserControl
    {
        protected bool[] permissions = new bool[4];
        public StreetsUserControl()
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
            dataGrid.ItemsSource = Data.ReadData<Street>();
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            string name = inputTextBox.Text;
            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                MessageBox.Show("Введите элемент для добавления");
                return;
            }
            try
            {
                Data.WriteData<Street, string>(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить новую запись");
                return;
            }
            if (permissions[0]) FillDataGrid(); // если можно читать - обновляем таблицу
            if (!permissions[0]) MessageBox.Show("Элемент добавлен");
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e) // выделяем элемент, пишем в текстбок, меняем
        {
            Street b = dataGrid.SelectedItem as Street; // добавить поиск
            string newName = inputTextBox.Text;

            if (b == null || String.IsNullOrEmpty(newName) || newName.Length < 2)
            {
                MessageBox.Show("Старый элемент не выбран или длина нового элемента меньше двух");
                return;
            }
            try
            {
                Data.EditData<Street, string>(b.Name, newName);
            }
            catch (SqliteException ex)
            {
                MessageBox.Show("Не удалось обновить запись");
                return;
            }
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
                Street b = dataGrid.SelectedItem as Street;
                if (b != null)
                {
                    try
                    {
                        Data.DeleteData<Street, string>(b.Name);
                    }
                    catch (SqliteException ex)
                    {
                        MessageBox.Show("Нелзя удалить используемый элемент");
                        return;
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show("Данные невозможно удалить");
                        return;
                    }
                    if (permissions[0]) FillDataGrid();
                }
            }
            else if (result == MessageBoxResult.Yes)
            {
                string toDelete = inputTextBox.Text;
                if (!String.IsNullOrEmpty(toDelete))
                {
                    try
                    {
                        Data.DeleteData<Street, string>(toDelete);
                    }
                    catch (SqliteException ex)
                    {
                        MessageBox.Show("Нелзя удалить используемый элемент");
                        return;
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show("Данные невозможно удалить");
                        return;
                    }
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
                dataGrid.ItemsSource = Data.SearchData<Street, string>(search);
            }
            else
            {
                MessageBox.Show("Введите элемент поиска");
            }
        }
    }
}
