using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda
{
    /// <summary>
    /// Класс для работы с БД для пользователей
    /// </summary>
    class UserVerifier : IVerifyUser
    {
        public async Task<bool> VerifyUser(User user)
        {
            using (var db = new ApplicationContext())
            {
                User existingUser = await db.Users.FirstOrDefaultAsync(x => x.Login == user.Login);
                
                if (existingUser != null)
                {
                    //if (BCrypt.Net.BCrypt.Verify(existingUser.Password, user.Password))
                    if (BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
                    //if (user.Password == existingUser.Password)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }
}
