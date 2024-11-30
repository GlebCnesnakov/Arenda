using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions
{
    internal interface IVerifyPermissions
    {
        public bool[] VerifyPermissions(string login, string menuItemName);
    }
}
