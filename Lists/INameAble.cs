﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public interface INameAble<T>
    {
        T Name { get; set; }
    }
}
