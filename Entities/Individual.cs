using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Individual")]
    public class Individual
    {
        [Key]
        public int ID { get; set; }
        [Column("series")]
        public string Series {  get; set; }
        [Column("number")]
        public string Number { get; set; }
        [Column("date_of_issue")]
        public string Date { get; set; }
        [Column("issued_by")]
        public string IssuedBy {  get; set; }
        public Individual() { }
        public Individual(string series, string number, string date, string issuedby)
        {
            Series = series;
            Number = number;
            Date = date;
            IssuedBy = issuedby;
        }

    }
}
