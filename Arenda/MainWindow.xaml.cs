using Microsoft.Extensions.Options;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace Arenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Database.db");
            
            //MessageBox.Show(System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Database.db")));
            

        }

        private async void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            if (login.Length < 4)
            {
                MessageBox.Show("Длина логина меньше 4 символов");
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Длина пароля меньше 6 символов");
                return;
            }
            
            // Обращение к модели
            User user = new(login, password);
            bool isVerified = await user.VerifyUser(new UserVerifier());

            if (isVerified)
            {
                
                MainMenu menu = new MainMenu();
                menu.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new();
            rw.Show();
            Hide();
        }
    }
}