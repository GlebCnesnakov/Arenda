using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda
{
    class UserRegistrar : IRegistrateUser
    {
        public async Task<bool> RegisterUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Login == user.Login);
                string newpass = BCrypt.Net.BCrypt.HashPassword(user.Password);
                if (existingUser == null)
                {
                    await db.Users.AddAsync(new User(user.Login, newpass, user.Role));
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
