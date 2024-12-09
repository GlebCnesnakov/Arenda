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
    /// Логика взаимодействия для AddIndividualRentorForm.xaml
    /// </summary>
    public partial class AddIndividualRentorForm : Window
    {
        Rentor rentorForEdit;
        public AddIndividualRentorForm(Rentor rentor = null)
        {
            InitializeComponent();
            rentorForEdit = rentor;
            if (rentorForEdit != null)
            {
                NameTextBox.Text = rentorForEdit.Name;
                SurnameTextBox.Text = rentorForEdit.Surname;
                MiddleNameTextBox.Text = rentorForEdit.MiddleName;
                PhoneTextBox.Text = rentorForEdit.Phone;
                PassportSeriesTextBox.Text = rentorForEdit.Individual.Series;
                PassportNumberTextBox.Text = rentorForEdit.Individual.Number;
                IssuedByTextBox.Text = rentorForEdit.Individual.IssuedBy;
                DateOfIssueTextBox.Text = rentorForEdit.Individual.Date;
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
            string series = PassportSeriesTextBox.Text;
            if (String.IsNullOrEmpty(series) || series.Length != 4)
            {
                MessageBox.Show("Неверная серия паспорта");
                return null;
            }
            string number = PassportNumberTextBox.Text;
            if (String.IsNullOrEmpty(number) || number.Length != 6)
            {
                MessageBox.Show("Неверный номер паспорта");
                return null;
            }
            string dateOfIssue = DateOfIssueTextBox.Text;
            string issuedBy = IssuedByTextBox.Text;
            if (String.IsNullOrEmpty(issuedBy) || issuedBy.Length < 10)
            {
                MessageBox.Show("Неверное место выдачи");
                return null;
            }
            if (!String.IsNullOrEmpty(dateOfIssue) && dateOfIssue.Length == 10)
            {
                try
                {
                    DateTime date = DateTime.Parse(dateOfIssue);
                    DateTime dt = new DateTime(1970, 1, 1);
                    if (date < dt)
                    {
                        throw new FormatException();
                    }
                    else if (date > DateTime.Now)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверная дата выдачи паспорта\nФормат: 20xx-xx-xx");
                    return null;
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверная дата выдачи паспорта\nФормат: 20xx-xx-xx");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Неверная запись даты выдачи\nФормат: 20xx-xx-xx");
                return null;
            }

            Individual individual = new Individual(series, number, dateOfIssue, issuedBy);
            return new Rentor(name, surname, middleName, phone, null, null, individual, null);
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            if (rentorForEdit == null) // редактирование
            {
                Rentor rentor = CheckDataAndGetRentor();
                if (rentor != null)
                {
                    try
                    {
                        Data.WriteData(rentor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось добавить новую запись " + ex.Message);
                        return;
                    }
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
                    try
                    {
                        Data.EditData<Individual>(editedRentor);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Не удалось записать новые данные");
                        return;
                    }
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
                    return;
                }
            }
            
        }
    }
}
