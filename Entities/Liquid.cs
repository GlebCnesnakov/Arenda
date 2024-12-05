using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("LiquidEntity")]
    public class Liquid
    {
        [Key]
        public int ID {  get; set; }
        [Column("name")]
        public string NameLiquid {  get; set; }

        [Column("id_street")]
        [ForeignKey(nameof(Street))]
        public int StreetID { get; set; }
        public Street Street {  get; set; }

        [Column("identification_number")]
        public string INN {  get; set; }

        [Column("id_bank")]
        [ForeignKey(nameof(Bank))]
        public int BankID { get; set; }
        public Bank Bank {  get; set; }

        [Column("id_district")]
        [ForeignKey(nameof(District))]
        public int DistrictID { get; set; }
        public District District { get; set; }

        [Column("building_number")]
        public int BuildingNumber {  get; set; }
        [Column("housing")]
        public int? Housing {  get; set; }
        public Liquid() { }
        public Liquid(string name, Street street, string inn, Bank bank, District district, int buildingnumber, int? housing)
        {
            NameLiquid = name;
            Street = street;
            INN = inn;
            Bank = bank;
            District = district;
            BuildingNumber = buildingnumber;
            Housing = housing;
        }
    }
}
