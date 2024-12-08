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

namespace Contracts
{
    /// <summary>
    /// Логика взаимодействия для ContractUserControl.xaml
    /// </summary>
    public partial class ContractUserControl : UserControl
    {
        bool[] permissions;
        public ContractUserControl()
        {
            InitializeComponent();
            permissions = new UserPermissionsVerifier().VerifyUser();
            if (permissions[0])
            {
                FillDataGrid();
                moreButton.IsEnabled = true;
                moreButton.Visibility = Visibility.Visible;
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

        public void FillDataGrid()
        {
            dataGrid.ItemsSource = Data.ReadContracts();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string searchstring = searchTextBox.Text;
            if (!String.IsNullOrEmpty(searchstring))
            {
                try
                {
                    Int32.Parse(searchstring);
                    dataGrid.ItemsSource = Data.SearchContract(searchstring);
                }
                catch(Exception)
                {
                    MessageBox.Show("Не удалось найти запись");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите номер для поиска");
            }
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddContractForm addContractForm = new AddContractForm();
            addContractForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран контракт");
            }
            AddContractForm addContractForm = new AddContractForm(dataGrid.SelectedItem as Contract);
            addContractForm.ShowDialog();
            if (permissions[0]) FillDataGrid();
        }
        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                try
                {
                    Data.DeleteContract(dataGrid.SelectedItem as Contract);
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Не удалось удалить помещение");
                    return;
                }
                FillDataGrid();
            }
            else MessageBox.Show("Помещение не выбрано");

        }

        private void ButtonClickMore(object sender, RoutedEventArgs e)
        {
            Contract contract = dataGrid.SelectedItem as Contract;
            MoreAboutContractForm more = new MoreAboutContractForm(contract);
            more.ShowDialog();
        }
    }
}
