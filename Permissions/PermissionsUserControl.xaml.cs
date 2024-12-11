using Arenda;
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


namespace Permissions
{
    /// <summary>
    /// Логика взаимодействия для PermissionsUserControl.xaml
    /// </summary>
    public partial class PermissionsUserControl : UserControl
    {
        public PermissionsUserControl()
        {
            InitializeComponent();
            FillComboboxes();
            this.KeyDown += PermissionsKeyDown;
        }
        private void FillComboboxes()
        {
            string[] logins = Users.GetLogins();
            string[] items = Items.GetItems();
            if (logins != null)
            {
                foreach (string log in logins)
                {
                    loginCombobox.Items.Add(log);
                    
                }
            }
            if (items != null)
            {
                foreach(string item in items)
                {
                    
                    itemCombobox.Items.Add(item);
                }
            }
        }

        private void Button_Click_Set(object sender, RoutedEventArgs e)
        {
            //проверить на повторное присваивание
            //задает чекбоксы, жмет кнопку, изменения вносятся
            bool[] permissions =
            {
                readCheckBox.IsChecked ?? false,
                writeCheckBox.IsChecked ?? false,
                editCheckBox.IsChecked ?? false,
                deleteCheckBox.IsChecked ?? false
            };
            UserPermission up = new UserPermission(loginCombobox.SelectedItem.ToString(), itemCombobox.SelectedItem.ToString());
            up.SavePermissions(permissions);
            MessageBox.Show("Данные сохранены");
        }



        private void ComboBoxSelected(object sender, SelectionChangedEventArgs e)
        {
            if (loginCombobox.SelectedItem != null && itemCombobox.SelectedItem != null)
            {
                //выдать чекбоксы
                UserPermission up = new UserPermission(loginCombobox.SelectedItem.ToString(), itemCombobox.SelectedItem.ToString());
                bool[] permissions = up.VerifyPermission(new UserPermissionsVerifier());
                readCheckBox.IsChecked = permissions[0];
                writeCheckBox.IsChecked = permissions[1];
                editCheckBox.IsChecked = permissions[2];
                deleteCheckBox.IsChecked = permissions[3];
                setButton.IsEnabled = true;
            }
            else
            {
                setButton.IsEnabled = false;
            }
        }

        void PermissionsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var focused = FocusManager.GetFocusedElement(this);
                if (focused is Button button) button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, button));
                else if (focused is CheckBox checkBox)
                {
                    checkBox.IsChecked = !checkBox.IsChecked;
                    var eventType = checkBox.IsChecked == true ? CheckBox.CheckedEvent : CheckBox.UncheckedEvent;
                    checkBox.RaiseEvent(new RoutedEventArgs(eventType, checkBox));
                }
            }
        }
    }
}
