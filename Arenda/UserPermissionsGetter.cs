using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arenda
{
    class UserPermissionsGetter : IGetPermissions
    {
        public List<UserPermissions> GetUserPermissions(User user)
        {
            
            using (var db = new ApplicationContext())
            {
                try
                {
                    List<UserPermissions> up = db.UserPermission.Where(x => x.id_user == user.ID).ToList();

                    return up;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Не удалось найти разрешения для пользователя");
                    return null;
                }
            }
        }
    }
}
