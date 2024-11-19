using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda
{
    public interface IGetPermissions
    {
        List<UserPermissions> GetUserPermissions(User user);
    }
}
