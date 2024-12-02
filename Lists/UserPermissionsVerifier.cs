using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Arenda;

namespace Lists
{
    /// <summary>
    /// Класс для проверки прав пользователя для справочника
    /// </summary>
    internal class UserPermissionsVerifier
    {
        public bool[] VerifyUser()
        {
            int currentMenuItemID = (int)Application.Current.Properties["CurrentMenuItemID"];
            User user = Application.Current.Properties["CurrentUser"] as User;

            using (var db = new ListsApplicationContext())
            {
                UserPermissions up = null;
                try
                {
                    up = db.UserPermission.FirstOrDefault(x => x.id_user == user.ID && x.IdMenuItem == currentMenuItemID);
                }
                catch(Exception e)
                {
                    MessageBox.Show("НЕ удалось получить записи о доступе");
                }
                return
                    [
                        up.CanRead > 0 ? true : false,
                        up.CanWrite > 0 ? true : false,
                        up.CanEdit > 0 ? true : false,
                        up.CanDelete > 0 ? true : false
                    ];
            }
        }
    }
}
