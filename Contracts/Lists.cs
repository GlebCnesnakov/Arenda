using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [Table("RentPurpose")]
    public class RentPurpose
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Purpose { get; set; }
        public override string ToString()
        {
            return $"{Purpose}";
        }
    }

    [Table("Payment_Frequency")]
    public class PaymentFrequency
    {
        [Key]
        public int ID { get; set; }
        [Column("frequency")]
        public int Frequency { get; set; }
        public override string ToString()
        {
            return $"{Frequency} д.";
        }
    }

    [Table("Street")]
    public class Street
    {
        [Key]
        public int ID { get; set; }
        [Column("street")]
        public string Name { get; set; }
    }

    [Table("District")]
    public class District
    {
        [Key]
        public int ID { get; set; }
        [Column("district")]
        public string Name { get; set; }
    }
}
