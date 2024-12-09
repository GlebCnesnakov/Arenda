using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premises
{
    [Table("Premises")]
    public class Premises : InterfaceID
    {
        [Key]
        public int ID { get; set; }
        [Column("apartment_number")]
        public int? ApartmentNumber { get; set; }
        [Column("premises_number")]
        public int? PremisesNumber { get; set; }
        [Column("floor_number")]
        public int FloorNumber { get; set; }
        [Column("area")]
        public int Area {  get; set; }
        [Column("phone")]
        public bool IsPhone { get; set; }
        [Column("housing")]
        public int? Housing { get; set; }

        [Column("id_decoration")]
        [ForeignKey(nameof(Decoration))]
        public int DecorationID { get; set; }
        public Decoration Decoration { get; set; }

        [Column("id_building")]
        [ForeignKey(nameof(Building))]
        public int BuildingID { get; set; }
        public Building Building{ get; set; }

        public Premises() { }
        public Premises(int? apartmentNumber, int? premisesNumber, int floorNumber, int area, bool isphone, int? housing, Decoration decoration, Building building)
        {
            ApartmentNumber = apartmentNumber;
            PremisesNumber = premisesNumber;
            FloorNumber = floorNumber;
            Area = area;
            IsPhone = isphone;
            Housing = housing;
            Decoration = decoration;
            Building = building;
        }

        public string DecorationName => Decoration.Name ?? "N/A";
        public string Address => Building.ToString() ?? "N/A";
        
    }
}
