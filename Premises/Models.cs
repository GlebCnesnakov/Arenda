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
        public int Area { get; set; }
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
        public Building Building { get; set; }

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
