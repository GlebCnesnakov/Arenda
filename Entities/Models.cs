using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
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

        [Column("id_individual")]
        [ForeignKey(nameof(Individual))]

        public int? IndividualID { get; set; }

        [Column("id_legal_entity")]
        [ForeignKey(nameof(Legal))]

        public int? LegalID { get; set; }

        public Individual? Individual { get; set; }
        public Liquid? Legal { get; set; }
        public Rentor() { }
        public Rentor(string name, string surname, string middlename, string phone, int? indiID, int? legalID, Individual indi, Liquid liq)
        {
            Name = name;
            Surname = surname;
            MiddleName = middlename;
            Phone = phone;
            IndividualID = indiID;
            LegalID = legalID;
            Individual = indi;
            Legal = liq;
        }
        public string PassportSeries => Individual?.Series ?? "N/A";
        public string PassportNumber => Individual?.Number ?? "N/A";
        public string DateOfIssue => Individual?.Date ?? "N/A";
        public string IssuedBy => Individual?.IssuedBy ?? "N/A";

        public string NameLiquid => Legal?.NameLiquid ?? "N/A";
        public string Street => Legal?.Street.Name ?? "N/A";
        public string INN => Legal?.INN ?? "N/A";
        public string Bank => Legal?.Bank.Name ?? "N/A";
        public string District => Legal?.District.Name ?? "N/A";
        public int? BuildingNumber => Legal?.BuildingNumber;
        public int? Housing => Legal?.Housing;

    }
    [Table("LiquidEntity")]
    public class Liquid
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string NameLiquid { get; set; }

        [Column("id_street")]
        [ForeignKey(nameof(Street))]
        public int StreetID { get; set; }
        public Street Street { get; set; }

        [Column("identification_number")]
        public string INN { get; set; }

        [Column("id_bank")]
        [ForeignKey(nameof(Bank))]
        public int BankID { get; set; }
        public Bank Bank { get; set; }

        [Column("id_district")]
        [ForeignKey(nameof(District))]
        public int DistrictID { get; set; }
        public District District { get; set; }

        [Column("building_number")]
        public int BuildingNumber { get; set; }
        [Column("housing")]
        public int? Housing { get; set; }
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

    [Table("Individual")]
    public class Individual
    {
        [Key]
        public int ID { get; set; }
        [Column("series")]
        public string Series { get; set; }
        [Column("number")]
        public string Number { get; set; }
        [Column("date_of_issue")]
        public string Date { get; set; }
        [Column("issued_by")]
        public string IssuedBy { get; set; }
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
