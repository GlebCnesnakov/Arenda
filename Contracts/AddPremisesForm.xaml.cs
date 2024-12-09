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
    /// Логика взаимодействия для AddPremisesForm.xaml
    /// </summary>
    public partial class AddPremisesForm : Window
    {
        int rent, rentalPeriod;
        RentPurpose purpose;
        Premises premises;
        Contract contract;
        ContractPremises contractPremisesForEdit;
        public AddPremisesForm(Contract contract = null, ContractPremises contractPremisesForEdit = null)
        {
            InitializeComponent();
            List<Premises> premises = Data.GetPremises();
            if (contractPremisesForEdit != null) premises.Add(contractPremisesForEdit.Premises);
            List<RentPurpose> purposes = Data.GetLists<RentPurpose>();
            foreach(Premises p in premises)
            {
                PremisesComboBox.Items.Add(p);
            }
            foreach(RentPurpose purpose in purposes)
            {
                RentPurposeComboBox.Items.Add(purpose);
            }
            this.contract = contract;
            if (contractPremisesForEdit != null)
            {
                this.contractPremisesForEdit = contractPremisesForEdit;
                PremisesComboBox.SelectedItem = premises.FirstOrDefault(x => x.ID == contractPremisesForEdit.Premises.ID);
                RentPurposeComboBox.SelectedItem = purposes.FirstOrDefault(x => x.ID == contractPremisesForEdit.RentPurpose.ID);
                RentalPeriodTextBox.Text = contractPremisesForEdit.RentalPeriod.ToString();
                RentTextBox.Text = contractPremisesForEdit.Rent.ToString();
            }
        }

        private void ButtonClickAddPremises(object sender, RoutedEventArgs e)
        {
            try
            {
                rent = Int32.Parse(RentTextBox.Text);
                rentalPeriod = Int32.Parse(RentalPeriodTextBox.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверные значения для платы или срока аренды");
                return;
            }
            premises = PremisesComboBox.SelectedItem as Premises;
            purpose = RentPurposeComboBox.SelectedItem as RentPurpose;
            ContractPremises contractPremises = new ContractPremises(premises, contract, purpose, rentalPeriod, rent);
            if (contractPremisesForEdit == null)
            {
                try
                {
                    Data.WritePremisesForContract(contractPremises);
                    MessageBox.Show("Помещение добавлено");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось добавить помещение");
                    return;
                }
            }
            else
            {
                try
                {
                    contractPremises.ContractID = contractPremisesForEdit.ContractID;
                    contractPremises.ID = contractPremisesForEdit.ID;
                    Data.EditPremisesOfContract(contractPremises);
                    MessageBox.Show("Помещение редактировано");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось редактировать помещение");
                    return;
                }
            }
        }
    }
}
