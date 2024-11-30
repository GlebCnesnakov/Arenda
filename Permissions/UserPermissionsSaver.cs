using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Arenda;

namespace Permissions
{
    internal class UserPermissionsSaver
    {
        public void SaveUserPermissions(bool[] permissions, string login, string item)
        {
            using (var db = new ApplicationContext())
            {
                int userId = Int32.MaxValue;
                int idItem = Int32.MaxValue;
                userId = (int)Application.Current.Properties["UserIdForPermission"]; // Вытаскиваем id из самой программы
                idItem = (int)Application.Current.Properties["ItemIdForPermission"];
                int permissionID = (int)Application.Current.Properties["PermissionID"];
                try
                {
                    //UserPermissions up = db.UserPermission.FirstOrDefault(x => x.id_user == userId && x.IdMenuItem == idItem);
                    //up.CanRead = permissions[0] == false ? 0 : 1;
                    //up.CanWrite = permissions[1] == false ? 0 : 1;
                    //up.CanEdit = permissions[2] == false ? 0 : 1;
                    //up.CanDelete = permissions[3] == false ? 0 : 1;
                    int canread = permissions[0] ? 1 : 0;
                    int canwrite = permissions[1] ? 1 : 0;
                    int canedit = permissions[2] ? 1 : 0;
                    int candelete = permissions[3] ? 1 : 0;
                    //UserPermissions up = new UserPermissions(userId, idItem, canread, canwrite, canedit, candelete);
                    UserPermissions up = new UserPermissions {
                        ID = permissionID,
                        id_user = userId,
                        IdMenuItem = idItem,
                        CanRead = canread,
                        CanWrite = canwrite,
                        CanEdit = canedit,
                        CanDelete = candelete
                    };
                    db.UserPermission.Update(up);
                    db.SaveChanges();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ы");
                }
                
            }
        }
    }
}
