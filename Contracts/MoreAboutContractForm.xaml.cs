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
using System.Windows.Shapes;

namespace Contracts
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutContractForm.xaml
    /// </summary>
    public partial class MoreAboutContractForm : Window
    {
        public MoreAboutContractForm(Contract contract)
        {
            InitializeComponent();
            titleTextBox.Text = $"Договор {contract.ContractNumber}";
            dataGrid.ItemsSource = Data.ReadPremisesOfContract(contract);
        }
    }
}
