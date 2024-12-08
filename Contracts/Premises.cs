using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// Класс Premises для хранения данных об адресе помещения
    /// </summary>
    [Table("Premises")]
    public class Premises
    {
        [Key]
        public int ID { get; set; }
        [Column("apartment_number")]
        public int? ApartmentNumber { get; set; }
        [Column("premises_number")]
        public int? PremisesNumber { get; set; }
        [Column("housing")]
        public int? Housing { get; set; }
        [Column("id_building")]
        [ForeignKey(nameof(Building))]
        public int BuildingID { get; set; }
        public Building Building { get; set; }

        public override string ToString()
        {
            var components = new List<string> { Building.ToString() };

            if (ApartmentNumber != null)
                components.Add($"кв.{ApartmentNumber}");
            if (PremisesNumber != null)
                components.Add($"пом.{PremisesNumber}");
            if (Housing != null)
                components.Add($"корп.{Housing}");

            return string.Join(" ", components);
        }
    }
}
