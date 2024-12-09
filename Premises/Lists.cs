using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premises
{
    [Table("Decoration")]
    public class Decoration
    {
        [Key]
        public int ID { get; set; }
        [Column("decoration_type")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    [Table("Street")]
    public class Street
    {
        [Key]
        public int ID { get; set; }
        [Column("street")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    [Table("District")]
    public class District
    {
        [Key]
        public int ID { get; set; }
        [Column("district")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
