using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Arenda;

namespace ChangePassword
{
    internal class PasswordChanger : IChangePassword
    {
        public PasswordChanger() { }
        public bool ChangePassword(string password)
        {
            var currentUser = Application.Current.Properties["CurrentUser"] as User;
            using (var db = new ApplicationContext())
            {
                User user = null;
                try
                {
                    user = db.Users.FirstOrDefault(x => x.Login == currentUser.Login);
                    user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                    db.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
