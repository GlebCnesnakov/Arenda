using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premises
{
    [Table("Building")]
    public class Building : InterfaceID
    {
        [Key]
        public int ID { get; set; }
        [Column("floor_count")]
        public int FloorCount { get; set; }
        [Column("rent_places")]
        public int RentPlaces { get; set; }
        [Column("phone_comandant")]
        public string Phone { get; set; }
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
        public Building() { }
        public Building(int floorcount, int rentplaces, string phone, int buildingnumber, Street street, District district)
        {
            FloorCount = floorcount;
            RentPlaces = rentplaces;
            Phone = phone;
            BuildingNumber = buildingnumber;
            Street = street;
            District = district;
        }

        public override string ToString()
        {
            return $"{DistrictName}, {StreetName}, д.{BuildingNumber}";
        }

        public string StreetName => Street.Name ?? "N/A";
        public string DistrictName => District.Name ?? "N/A";
    }
}
