using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Класс для работы с добавлением и изменением
    /// </summary>
    public partial class AddContractForm : Window
    {
        string startDate = null, endDate = null;
        int penalty = 0, contractNumber = 0;
        string? comments = null;
        Rentor rentor;
        PaymentFrequency frequency;
        Contract contract;
        Contract contractForEdit;
        public AddContractForm(Contract contractForEdit = null)
        {
            InitializeComponent();
            var rentors = Data.GetLists<Rentor>();
            var frequencies = Data.GetLists<PaymentFrequency>();
            paymentFrequencyComboBox.ItemsSource = frequencies;
            rentorComboBox.ItemsSource = rentors;
            
            if (contractForEdit != null)
            {
                this.contractForEdit = contractForEdit;
                ContractNumberTextBox.Text = contractForEdit.ContractNumber.ToString();
                StartDataTextBox.Text = contractForEdit.StartDate;
                EndDataTextBox.Text = contractForEdit.EndDate;
                PenaltyTextBox.Text = contractForEdit.Penalty.ToString();
                CommentTextBox.Text = contractForEdit.Comments;
                rentorComboBox.SelectedItem = rentors.FirstOrDefault(r => r.ID == contractForEdit.Rentor.ID);
                paymentFrequencyComboBox.SelectedItem = frequencies.FirstOrDefault(f => f.ID == contractForEdit.PaymentFrequency.ID);
                FillPremisesDataGrid(contractForEdit ?? contract);
            }
            
        }

        void FillPremisesDataGrid(Contract contract)
        {
            dataGrid.ItemsSource = Data.ReadPremisesOfContract(contract);
        }

        private void ButtonClickSaveContract(object sender, RoutedEventArgs e)
        {
            comments = CommentTextBox.Text;
            startDate = StartDataTextBox.Text;
            endDate = EndDataTextBox.Text;
            if ((!String.IsNullOrEmpty(startDate) && startDate.Length == 10) || (!String.IsNullOrEmpty(endDate) && endDate.Length == 10))
            {
                try
                {
                    DateTime date = DateTime.Parse(startDate);
                    DateTime date1 = DateTime.Parse(endDate);
                    DateTime dt = new DateTime(1970, 1, 1);
                    if ((date < dt || date > DateTime.Now) || (date1 < dt) || (date > date1)) throw new FormatException();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверная дата начала\nФормат: 20xx-xx-xx");
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверная дата начала\nФормат: 20xx-xx-xx");
                    return;
                }
            }
            
            try{ penalty = Int32.Parse(PenaltyTextBox.Text); }
            catch(FormatException){ MessageBox.Show("Неверное значение для штрафа");return; }
            try{ contractNumber = Int32.Parse(ContractNumberTextBox.Text); if (ContractNumberTextBox.Text.Length != 9) throw new FormatException(); } 
            catch(FormatException){ MessageBox.Show("Неверное значение для номера контракта"); return;}
            rentor = rentorComboBox.SelectedItem as Rentor;
            frequency = paymentFrequencyComboBox.SelectedItem as PaymentFrequency;
            contract = new Contract(contractNumber, startDate, endDate, comments, penalty, rentor, frequency);
            if (contractForEdit == null) {
                try
                {
                    Data.WriteContract(contract);
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Не удалось записать контракт");
                    return;
                }
                MessageBox.Show("Контракт добавлен. Можно работать с помещениями");
            }
            else
            {
                try
                {
                    contract.ID = contractForEdit.ID;
                    Data.EditContract(contract);
                }
                catch(DbUpdateException)
                {
                    MessageBox.Show("Не удалось редактировать контракт");
                    return;
                }
                MessageBox.Show("Контракт редактирован. Можно работать с помещениями");
            }
            dataGridScrollViewer.Visibility = Visibility.Visible;
            premiseslabel.Visibility = Visibility.Visible;
            dataGrid.Visibility = Visibility.Visible;
            buttonsStackPanel.Visibility = Visibility.Visible;
            writeButton.Visibility = Visibility.Visible;
            addcontractButton.Visibility = Visibility.Hidden;
            ContractNumberTextBox.IsEnabled = false;
            StartDataTextBox.IsEnabled = false;
            EndDataTextBox.IsEnabled = false;
            PenaltyTextBox.IsEnabled = false;
            CommentTextBox.IsEnabled = false;
            rentorComboBox.IsEnabled = false;
            paymentFrequencyComboBox.IsEnabled = false;
        }

        private void ButtonClickAddPremises(object sender, RoutedEventArgs e)
        {
            AddPremisesForm addPremisesForm = new AddPremisesForm(contract);
            addPremisesForm.ShowDialog();
            FillPremisesDataGrid(contractForEdit ?? contract);
        }

        private void ButtonClickAddContract(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonClickEditPremises(object sender, RoutedEventArgs e) {

            if (dataGrid.SelectedItem != null)
            {
                AddPremisesForm editPremisesForm = new AddPremisesForm(contractPremisesForEdit: dataGrid.SelectedItem as ContractPremises);
                editPremisesForm.ShowDialog();
                FillPremisesDataGrid(contractForEdit ?? contract);
            }
            else MessageBox.Show("Помещение не выбрано");
        }

        private void ButtonClickDeletePremises(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                try
                {
                    Data.DeletePremisesFromContract(dataGrid.SelectedItem as ContractPremises);
                }
                catch(DbUpdateException)
                {
                    MessageBox.Show("Не удалось удалить помещение");
                    return;
                }
                FillPremisesDataGrid(contractForEdit ?? contract);
            }
            else MessageBox.Show("Помещение не выбрано");
        }
    }
}
