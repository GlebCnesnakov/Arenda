using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda
{
    /// <summary>
    /// Класс модель пользователь
    /// </summary>
    [Table("Users")]
    class User
    {
        public int ID {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public Task<bool> VerifyUser(IVerifyUser verifier)
        {
            return verifier.VerifyUser(this);
        }
        public Task<bool> RegisterUser(IRegistrateUser registrar)
        {
            return registrar.RegisterUser(this);
        }
    }
}
