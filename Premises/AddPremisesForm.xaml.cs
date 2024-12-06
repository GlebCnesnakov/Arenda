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

namespace Premises
{
    /// <summary>
    /// Логика взаимодействия для AddPremisesForm.xaml
    /// </summary>
    public partial class AddPremisesForm : Window
    {
        Premises premises;
        public AddPremisesForm(Premises premises = null)
        {
            InitializeComponent();
            this.premises = premises; // premises для редактирования
            List<Decoration> decorations = Data.GetLists<Decoration>();
            List<Building> buildings = Data.ReadData<Building>();

            foreach (Decoration decoration in decorations)
            {
                DecorationComboBox.Items.Add(decoration.Name);
            }
            foreach (Building building in buildings)
            {
                BuildingComboBox.Items.Add(building.ToString());
            }

            if (premises != null)
            {
                ApartmentNumberTextBox.Text = premises.ApartmentNumber.ToString();
                PremisesNumberTextBox.Text = premises.PremisesNumber.ToString();
                IsPhoneCheckBox.IsChecked = premises.IsPhone;
                FloorNumberTextBox.Text = premises.FloorNumber.ToString();
                AreaTextBox.Text = premises.Area.ToString();
                HousingTextBox.Text = premises.Housing.ToString();
                DecorationComboBox.Text = premises.Decoration.Name;
                BuildingComboBox.Text = premises.Building.ToString();
            }

        }



        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            int? apartmentNumber = 0, premisesNumber = 0, housing = 0;
            int area = 0, floorNumber = 0;
            bool isPhone = false;
            string decoration = null, building = null;

            bool CheckValues()
            {
                if (String.IsNullOrEmpty(ApartmentNumberTextBox.Text))
                {
                    apartmentNumber = null;
                }
                else
                {
                    try
                    {
                        apartmentNumber = Int32.Parse(ApartmentNumberTextBox.Text);
                        if (apartmentNumber < 1 || apartmentNumber > 2000)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверное значение для номера квартиры");
                        return false;
                    }
                }

                if (String.IsNullOrEmpty(PremisesNumberTextBox.Text))
                {
                    premisesNumber = null;
                }
                else
                {
                    try
                    {
                        premisesNumber = Int32.Parse(PremisesNumberTextBox.Text);
                        if (premisesNumber < 1 || premisesNumber > 300)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверное значение для номера помещения");
                        return false;
                    }
                }

                if (String.IsNullOrEmpty(HousingTextBox.Text))
                {
                    housing = null;
                }
                else
                {
                    try
                    {
                        housing = Int32.Parse(HousingTextBox.Text);
                        if (housing < 1 || housing > 1000)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверное значение для корпуса");
                        return false;
                    }
                }

                try
                {
                    floorNumber = Int32.Parse(FloorNumberTextBox.Text);
                    if (floorNumber < 1 || floorNumber > 100)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверное значение этажа");
                    return false;
                }

                isPhone = IsPhoneCheckBox.IsChecked == true;

                try
                {
                    area = Int32.Parse(AreaTextBox.Text);
                    if (area < 1 || area > 1000)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверное значение для площади помещения");
                    return false;
                }

                try
                {
                    decoration = DecorationComboBox.SelectedItem.ToString();

                    building = BuildingComboBox.SelectedItem.ToString();
                }
                catch(Exception)
                {
                    MessageBox.Show("Не выбран тип отделки или здание");
                    return false;
                }
                
                return true;
            }

            if (premises == null) // Запись
            {
                if (CheckValues())
                {

                    Premises premises = new Premises(apartmentNumber, premisesNumber, floorNumber, area, isPhone, housing, new Decoration() { Name = decoration }, null);
                    try
                    {
                        Data.WritePremises(premises, building);
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
                    catch(InvalidOperationException)
                    {
                        MessageBox.Show("Не удалось осуществить запись: мест в здании нет");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось осуществить запись");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (CheckValues())
                {

                    Premises premises = new Premises(apartmentNumber, premisesNumber, floorNumber, area, isPhone, housing, new Decoration() { Name = decoration }, null);
                    premises.ID = this.premises.ID;
                    try
                    {
                        Data.EditPremises(premises, building);
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось обновить запись " + ex.Message);
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
