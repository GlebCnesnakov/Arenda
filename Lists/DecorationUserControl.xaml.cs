﻿using System;
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
    /// Логика взаимодействия для DecorationUserControl.xaml
    /// </summary>
    public partial class DecorationUserControl : UserControl
    {
        protected bool[] permissions = new bool[4];
        public DecorationUserControl()
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
            dataGrid.ItemsSource = Data.ReadData<Decoration>();
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            string name = inputTextBox.Text;
            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                MessageBox.Show("Введите элемент для добавления");
                return;
            }
            Data.WriteData<Decoration, string>(name);
            if (permissions[0]) FillDataGrid(); // если можно читать - обновляем таблицу
            if (!permissions[0]) MessageBox.Show("Элемент добавлен");
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e) // выделяем элемент, пишем в текстбок, меняем
        {
            Decoration b = dataGrid.SelectedItem as Decoration; // добавить поиск
            string newName = inputTextBox.Text;

            if (b == null || String.IsNullOrEmpty(newName) || newName.Length < 2)
            {
                MessageBox.Show("Старый элемент не выбран или длина нового элемента меньше двух");
                return;
            }
            Data.EditData<Decoration, string>(b.Name, newName);
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
                Decoration b = dataGrid.SelectedItem as Decoration;
                if (b != null)
                {
                    Data.DeleteData<Decoration, string>(b.Name);
                    if (permissions[0]) FillDataGrid();
                }
            }
            else if (result == MessageBoxResult.Yes)
            {
                string toDelete = inputTextBox.Text;
                if (!String.IsNullOrEmpty(toDelete))
                {
                    Data.DeleteData<Decoration, string>(toDelete);
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
                dataGrid.ItemsSource = Data.SearchData<Decoration, string>(search);
            }
            else
            {
                MessageBox.Show("Введите элемент поиска");
            }
        }
    }
}