using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// Класс Building для хранения части адреса
    /// </summary>
    [Table("Building")]
    public class Building
    {
        [Key]
        public int ID { get; set; }
        [Column("building_number")]
        public int BuildingNumber { get; set; }
        [Column("id_street")]
        [ForeignKey(nameof(Street))]
        public int StreetID { get; set; }
        public Street Street { get; set; }
        [Column("id_district")]
        [ForeignKey(nameof(District))]
        public int DistrictID { get; set; }
        public District District { get; set; }

        public override string ToString()
        {
            return $"{District.Name}, {Street.Name}, д.{BuildingNumber}";
        }
    }
}
