using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Arenda;

namespace Permissions
{
    internal class Users
    {
        public static string[] GetLogins()
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    return db.Users.Select(x => x.Login).ToArray();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
                }
                catch (Exception ex) // Обработка всех остальных ошибок
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                return null;
            }
        }
    }
}
