using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arenda
{
    class UserRegistrar : IRegistrateUser
    {
        public async Task<bool> RegisterUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Login == user.Login);
                string newpass = BCrypt.Net.BCrypt.HashPassword(user.Password);

                if (existingUser == null)
                {
                    try
                    {
                        User newUser = new User(user.Login, newpass);
                        await db.Users.AddAsync(newUser);
                        await db.SaveChangesAsync();
                        User userFromDB = db.Users.FirstOrDefault(u => u.Login == newUser.Login);
                        Application.Current.Properties["CurrentUser"] = userFromDB;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ошибка работы с БД");
                        return false;
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
