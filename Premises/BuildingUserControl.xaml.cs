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

namespace Premises
{
    /// <summary>
    /// Логика взаимодействия для BuildingUserControl.xaml
    /// </summary>
    public partial class BuildingUserControl : UserControl
    {
        bool[] permissions;
        public BuildingUserControl()
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

        void FillDataGrid()
        {
            dataGrid.ItemsSource = Data.ReadData<Building>();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string searchstring = searchTextBox.Text;
            if (!String.IsNullOrEmpty(searchstring))
            {
                dataGrid.ItemsSource = Data.SearchData<Building>(searchstring);
            }
            else
            {
                MessageBox.Show("Введите строку для поиска");
            }
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddBuildingForm addBuildingForm = new AddBuildingForm();
            addBuildingForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Building selectedBuilding = dataGrid.SelectedItem as Building;
            AddBuildingForm addBuildingForm = new AddBuildingForm(selectedBuilding);
            addBuildingForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            Building building = dataGrid.SelectedItem as Building;
            try
            {
                Data.DeleteBuilding(building);
                MessageBox.Show("Здание удалено. Связанные помещения удалены");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось удалить данные");
            }
            if (permissions[0]) FillDataGrid();
        }
    }
}
