﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lists
{
    [Table("Decoration")]
    public class Decoration : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("decoration_type")]
        public string Name { get; set; }
    }
}
