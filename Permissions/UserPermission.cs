using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions
{
    internal class UserPermission
    {
        string login;
        string itemMenuName;
        public UserPermission(string login, string itemMenuName)
        {
            this.login = login;
            this.itemMenuName = itemMenuName;
        }
        public bool[] VerifyPermission(IVerifyPermissions vp)
        {
            return vp.VerifyPermissions(login, itemMenuName);
        }
        public void SavePermissions(bool[] permissions)
        {
            UserPermissionsSaver us = new UserPermissionsSaver();
            us.SaveUserPermissions(permissions, login, itemMenuName);
        }
    }
}
