﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda
{
    public interface IVerifyUser
    {
        Task<bool> VerifyUser(User user);
    }
}
