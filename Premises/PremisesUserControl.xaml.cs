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
    /// Логика взаимодействия для PremisesUserControl.xaml
    /// </summary>
    public partial class PremisesUserControl : UserControl
    {
        bool[] permissions;
        public PremisesUserControl()
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
            dataGrid.ItemsSource = Data.ReadData<Premises>();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string searchstring = searchTextBox.Text;
            if (!String.IsNullOrEmpty(searchstring))
            {
                dataGrid.ItemsSource = Data.SearchData<Premises>(searchstring);
            }
            else
            {
                MessageBox.Show("Введите строку для поиска");
            }
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddPremisesForm addPremisesForm = new AddPremisesForm();
            addPremisesForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Premises selectedPremises = dataGrid.SelectedItem as Premises;
            AddPremisesForm addPremisesForm = new AddPremisesForm(selectedPremises);
            addPremisesForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            Premises premises = dataGrid.SelectedItem as Premises;
            try
            {
                Data.DeleteData<Premises>(premises);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить данные");
            }
            if (permissions[0]) FillDataGrid();
        }
    }
}
