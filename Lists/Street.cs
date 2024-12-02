using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lists
{
    [Table("Street")]
    public class Street : INameAble
    {
        [Key]
        public int ID { get; set; }
        [Column("street")]
        public string Name { get; set; }
    }
}
