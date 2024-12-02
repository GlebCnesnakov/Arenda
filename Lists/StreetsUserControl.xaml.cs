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
        bool[] permissions = new bool[4];
        public StreetsUserControl()
        {
            InitializeComponent();
            //проверка на разрешения
            UserPermissionsVerifier uv = new();
            permissions = uv.VerifyUser(); // Получили разрешения
            if (permissions[0])
            {
                FillDataGrid();
                searchButton.IsEnabled = true;
            }
            if (permissions[1])
            {
                writeButton.IsEnabled = true;
                writeButton.Visibility = Visibility.Visible;
            }
            if (permissions[2])
            {
                dataGrid.IsReadOnly = false;
                editButton.IsEnabled = true;
                editButton.Visibility = Visibility.Visible;
            }
            if (permissions[3])
            {
                deleteButton.IsEnabled = true;
                deleteButton.Visibility = Visibility.Visible;
            }
        }
        void FillDataGrid()
        {
            dataGrid.ItemsSource = Data.ReadData<Street>();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            string name = inputTextBox.Text;
            if (name == "") return;
            Data.WriteData<Street>(name);

        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {

        }
    }
}
