using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [Table("Rentor")]
    public class Rentor
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string Surname { get; set; }
        [Column("middle_name")]
        public string? MiddleName { get; set; }
        [Column("phone")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {MiddleName}, тлф:{Phone}";
        }
    }
}
