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
    /// Добавление и редактирование здания
    /// </summary>
    public partial class AddBuildingForm : Window
    {
        Building building;
        public AddBuildingForm(Building building = null)
        {
            InitializeComponent();
            this.building = building; // building для редактирования
            List<Street> streets = Data.GetLists<Street>();
            List<District> districts = Data.GetLists<District>();

            foreach (Street street in streets)
            {
                streetComboBox.Items.Add(street.Name);
            }
            foreach (District district in districts)
            {
                districtComboBox.Items.Add(district.Name);
            }

            if (building != null )
            {
                FloorCountTextBox.Text = building.FloorCount.ToString();
                RentPlacesTextBox.Text = building.RentPlaces.ToString();
                PhoneTextBox.Text = building.Phone;
                BuildingNumberTextBox.Text = building.BuildingNumber.ToString();
                streetComboBox.Text = building.Street.Name;
                districtComboBox.Text = building.District.Name;
            }
            
        }



        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            int floorcount = 0, rentplaces = 0, buildingNumber = 0;
            string phone = null, street = null, district = null;

            bool CheckValues()
            {
                try
                {
                    floorcount = Int32.Parse(FloorCountTextBox.Text);
                    if (floorcount < 1 || floorcount > 100)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверное значение для количества этажей");
                    return false;
                }

                try
                {
                    rentplaces = Int32.Parse(RentPlacesTextBox.Text);
                    if (rentplaces < 1 || rentplaces > 300)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверное значение для мест под аренду");
                    return false;
                }

                phone = PhoneTextBox.Text;
                if (String.IsNullOrEmpty(phone) || phone.Length != 12)
                {
                    MessageBox.Show("Неверный номер телефона\nФормат: +7xxxxxxxxxx");
                    return false;
                }

                try
                {
                    buildingNumber = Int32.Parse(BuildingNumberTextBox.Text);
                    if (buildingNumber < 1 || buildingNumber > 300)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверное значение для номера дома");
                    return false;
                }


                district = districtComboBox.SelectedItem.ToString();
                street = streetComboBox.SelectedItem.ToString();
                return true;
            }

            if (building == null) // Запись
            {
                if (CheckValues())
                {
                    Building building = new Building(floorcount, rentplaces, phone, buildingNumber, new Street() { Name = street }, new District() { Name = district });
                    try
                    {
                        Data.WriteBuilding(building);
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
                    
                    Building building = new Building(floorcount, rentplaces, phone, buildingNumber, new Street() { Name = street }, new District() { Name = district });
                    building.ID = this.building.ID;
                    if (building.RentPlaces < Data.GetOccupiedRentPlacesOfBuilding(building))
                    {
                        MessageBox.Show("Нельзя уменьшить количество");
                        return;
                    }
                    try
                    {
                        Data.EditBuilding(building);
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
                    catch(Exception ex)
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
