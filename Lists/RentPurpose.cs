using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lists
{
    [Table("RentPurpose")]
    public class RentPurpose : INameAble<string>
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
