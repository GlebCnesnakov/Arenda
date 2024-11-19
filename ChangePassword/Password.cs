using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangePassword
{
    internal class Password
    {
        IChangePassword passwordChanger { get; }
        public Password(IChangePassword passwordChanger)
        {
            this.passwordChanger = passwordChanger;
        }
        public bool ChangePassword(string password)
        {
            return passwordChanger.ChangePassword(password);
        }
    }
}
