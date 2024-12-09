
using Microsoft.Data.Sqlite;
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

namespace Entities
{
    /// <summary>
    /// Логика взаимодействия для LiquidUserControl.xaml
    /// </summary>
    public partial class LiquidUserControl : UserControl
    {
        bool[] permissions;
        public LiquidUserControl()
        {
            InitializeComponent();
            permissions = new UserPermissionsVerifier().VerifyUser();
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
        }

        private void FillDataGrid()
        {
            dataGrid.ItemsSource = Data.ReadData<Liquid>();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string searchstring = searchTextBox.Text;
            if (!String.IsNullOrEmpty(searchstring))
            {
                List<Rentor> rentors = Data.SearchData<Liquid>(searchstring);
                dataGrid.ItemsSource = rentors;
            }
            else
            {
                MessageBox.Show("Введите строку для поиска");
            }
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddLiquidRentorForm addLiquidRentorForm = new AddLiquidRentorForm();
            addLiquidRentorForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Rentor selectedRentor = dataGrid.SelectedItem as Rentor;
            AddLiquidRentorForm addLiquidRentorForm = new AddLiquidRentorForm(selectedRentor);
            addLiquidRentorForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            Rentor selectedRentor = dataGrid.SelectedItem as Rentor;
            try
            {
                Data.DeleteData(selectedRentor);
            }
            catch (SqliteException ex)
            {
                MessageBox.Show("Не удалось удалить запись " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить запись " + ex.Message);
                return;
            }
            if (permissions[0]) FillDataGrid();
            else MessageBox.Show("Запись удалена");
        }
    }
}
