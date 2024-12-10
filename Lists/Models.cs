using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    [Table("Bank")]
    public class Bank : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
    [Table("Decoration")]
    public class Decoration : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("decoration_type")]
        public string Name { get; set; }
    }
    [Table("District")]
    public class District : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("district")]
        public string Name { get; set; }
    }
    [Table("Payment_Frequency")]
    public class PaymentFrequency : INameAble<int>
    {
        [Key]
        public int ID { get; set; }
        [Column("frequency")]
        public int Name { get; set; }
    }
    [Table("RentPurpose")]
    public class RentPurpose : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
    [Table("Street")]
    public class Street : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("street")]
        public string Name { get; set; }
    }
}
