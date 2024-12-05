using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
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
