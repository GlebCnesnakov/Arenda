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

namespace Entities
{
    /// <summary>
    /// Логика взаимодействия для AddLiquidRentorForm.xaml
    /// </summary>
    public partial class AddLiquidRentorForm : Window
    {
        Rentor rentorForEdit;
        public AddLiquidRentorForm(Rentor rentor = null)
        {
            InitializeComponent();
            rentorForEdit = rentor;
            List<District> districts = Data.GetLists<District>();
            List<Bank> banks = Data.GetLists<Bank>();
            List<Street> streets = Data.GetLists<Street>();
            foreach(District district in districts)
            {
                districtComboBox.Items.Add(district.Name);
            }
            foreach (Bank bank in banks)
            {
                bankComboBox.Items.Add(bank.Name);
            }
            foreach (Street street in streets)
            {
                streetComboBox.Items.Add(street.Name);
            }
            if (rentorForEdit != null)
            {
                NameTextBox.Text = rentorForEdit.Name;
                SurnameTextBox.Text = rentorForEdit.Surname;
                MiddleNameTextBox.Text = rentorForEdit.MiddleName;
                PhoneTextBox.Text = rentorForEdit.Phone;
                NameLiquidtextbox.Text = rentorForEdit.NameLiquid;
                INNtextbox.Text = rentorForEdit.INN; //
                BuildingNumberTextBox.Text = rentorForEdit.BuildingNumber.ToString();
                HousingTextBox.Text = rentorForEdit.Housing.ToString();
                streetComboBox.Text = rentorForEdit.Street;
                districtComboBox.Text = rentorForEdit.District;
                bankComboBox.Text = rentorForEdit.Bank;
            }
        }

        Rentor CheckDataAndGetRentor()
        {
            string name = NameTextBox.Text;
            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                MessageBox.Show("Неверное имя");
                return null;
            }
            string surname = SurnameTextBox.Text;
            if (String.IsNullOrEmpty(surname) || surname.Length < 2)
            {
                MessageBox.Show("Неверная фамилия");
                return null;
            }
            string middleName = MiddleNameTextBox.Text;
            if (middleName.Length > 0 && middleName.Length < 6) // отчество может быть null
            {
                MessageBox.Show("Неверное отчество");
                return null;
            }
            string phone = PhoneTextBox.Text;
            if (String.IsNullOrEmpty(phone) || phone.Length < 12)
            {
                MessageBox.Show("Неверный номер телефона\nФормат: +7xxxxxxxxxx");
                return null;
            }
            string nameLiquid = NameLiquidtextbox.Text;
            if (String.IsNullOrEmpty(nameLiquid) || nameLiquid.Length < 5)
            {
                MessageBox.Show("Неверная имя юридического лица");
                return null;
            }
            string inn = INNtextbox.Text;
            if (String.IsNullOrEmpty(inn) || inn.Length != 12)
            {
                MessageBox.Show("Неверный ИНН");
                return null;
            }
            int buildingNumber;
            try
            {
                buildingNumber = Int32.Parse(BuildingNumberTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный номер здания");
                return null;
            }
            int? housing;
            try
            {
                housing = Int32.Parse(HousingTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный номер корпуса");
                return null;
            }
            string district = districtComboBox.SelectedItem.ToString();
            string bank = bankComboBox.SelectedItem.ToString();
            string street = streetComboBox.SelectedItem.ToString();


            Liquid liquid = new Liquid(nameLiquid, new Street() {Name = street}, inn, new Bank() {Name = bank}, new District() {Name = district}, buildingNumber, housing);
            return new Rentor(name, surname, middleName, phone, null, null, null, liquid);
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            if (rentorForEdit == null)
            {
                Rentor rentor = CheckDataAndGetRentor();
                if (rentor != null)
                {
                    if (Data.WriteData(rentor))
                    {
                        var result = MessageBox.Show(
                            "Запись добавлена. Выйти из режима добавления?",  // Текст сообщения
                            "Подтверждение",                       // Заголовок окна
                            MessageBoxButton.YesNo,                // Кнопки: "Да" и "Нет"
                            MessageBoxImage.Question               // Иконка: вопрос
                        );
                        if (result == MessageBoxResult.Yes)
                        {
                            this.Close();
                        }
                        else
                        {
                            foreach (var control in panelForTB.Children)
                            {
                                if (control is TextBox textBox)
                                {
                                    textBox.Text = String.Empty;
                                }
                                if (control is ComboBox combobox)
                                {
                                    combobox.SelectedItem = null;
                                }
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
                
            }
            else // редактирование
            {
                Rentor editedRentor = CheckDataAndGetRentor();

                if (editedRentor != null)
                {
                    editedRentor.ID = rentorForEdit.ID;
                    if (Data.EditData<Liquid>(editedRentor))
                    {
                        var result = MessageBox.Show(
                            "Запись редактирована. Выйти из режима редактирования?",  // Текст сообщения
                            "Подтверждение",                       // Заголовок окна
                            MessageBoxButton.YesNo,                // Кнопки: "Да" и "Нет"
                            MessageBoxImage.Question               // Иконка: вопрос
                        );
                        if (result == MessageBoxResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось записать новые данные");
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
