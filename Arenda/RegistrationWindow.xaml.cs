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

namespace Arenda
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            string passwordRepeat = PasswordRepeatTextBox.Password;
            if (login.Length < 4)
            {
                MessageBox.Show("Длина логина меньше 4 символов");
                return;
            }
            else if (password.Length < 6)
            {
                MessageBox.Show("Длина пароля меньше 6 символов");
                return;
            }
            else if (password != passwordRepeat)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }


            // Обращение к модели
            User user = new(login, password);
            bool isRegistrated = await user.RegisterUser(new UserRegistrar());
            
            if (isRegistrated)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Пользователь уже существует");
            }
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            MainWindow aw = new();
            aw.Show();
            Hide();
        }
    }
}
