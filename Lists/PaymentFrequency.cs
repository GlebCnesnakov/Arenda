﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lists
{
    [Table("Payment_Frequency")]
    public class PaymentFrequency : INameAble
    {
        [Key]
        public int ID { get; set; }
        [Column("frequency")]
        public string Name { get; set; }
    }
}