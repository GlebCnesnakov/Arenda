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

namespace ChangePassword
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordUserControl.xaml
    /// </summary>
    public partial class ChangePasswordUserControl : UserControl
    {
        public ChangePasswordUserControl()
        {
            InitializeComponent();
        }
        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {
            string firstPassword = PasswordFirst.Password;
            string secondPassword = PasswordSecond.Password;
            if (firstPassword != secondPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Password password = new Password(new PasswordChanger());
            if (password.ChangePassword(firstPassword))
            {
                MessageBox.Show("Пароль успешно изменён");

            }
            else
            {
                MessageBox.Show("Не удалось изменить пароль");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
