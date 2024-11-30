using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Arenda;

namespace Permissions
{
    internal class UserPermissionsVerifier : IVerifyPermissions
    {
        public bool[] VerifyPermissions(string login, string itemMenuName)
        {
            //найти id юзера
            //найти id пункта
            int userId = Int32.MaxValue;
            int idItem = Int32.MaxValue;
            UserPermissions userPermission = null;
            using (var db = new ApplicationContext())
            {
                try
                {
                    userId = db.Users.Where(x => x.Login == login).Select(x => x.ID).FirstOrDefault(); // Ищем id юзера
                    idItem = db.MainMenuItems.Where(x => x.Name == itemMenuName).Select(x => x.ID).FirstOrDefault(); // Ищем id пункта
                    userPermission = db.UserPermission.FirstOrDefault(x => x.id_user == userId && x.IdMenuItem == idItem);
                    Application.Current.Properties["UserIdForPermission"] = userId;
                    Application.Current.Properties["ItemIdForPermission"] = idItem;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось достать айди юзера или пункта или разрешения");
                }
                if (userPermission != null)
                {
                    Application.Current.Properties["PermissionID"] = userPermission.ID;
                    return
                    [
                        userPermission.CanRead != 0,
                        userPermission.CanWrite != 0,
                        userPermission.CanEdit != 0,
                        userPermission.CanDelete != 0
                    ];
                }
                else
                {
                    // Записей о доступе не было, добавляем запись
                    UserPermissions up = new UserPermissions(userId, idItem, 0, 0, 0, 0);
                    db.UserPermission.Add(up);
                    
                    db.SaveChanges();
                    Application.Current.Properties["PermissionID"] = db.UserPermission.FirstOrDefault(x => x.id_user == userId && x.IdMenuItem == idItem).ID;
                    return [false, false, false, false];
                }

            }
        }
    }
}
