using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
    [Table("Decoration")]
    public class Decoration
    {
        [Key]
        public int ID { get; set; }
        [Column("decoration_type")]
        public string Name { get; set; }
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
    [Table("Payment_Frequency")]
    public class PaymentFrequency
    {
        [Key]
        public int ID { get; set; }
        [Column("frequency")]
        public int Name { get; set; }
    }
    [Table("RentPurpose")]
    public class RentPurpose
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
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
    [Table("Building")]
    public class Building
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
    [Table("Premises")]
    public class Premises
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
        public override string ToString()
        {
            return $"{Building.District}, {Building.Street}, д.{Building.BuildingNumber}, кв.{(ApartmentNumber.HasValue ? ApartmentNumber.ToString() : "N/A")}, пом.{(PremisesNumber.HasValue ? PremisesNumber.ToString() : "N/A")} корп.{(Housing.HasValue ? Housing.ToString() : "N/A")}";
        }
        public string DecorationName => Decoration.Name ?? "N/A";
        public string Address => Building.ToString() ?? "N/A";
        public string Phone => IsPhone == true ? "Есть" : "Нет";
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
        public override string ToString()
        {
            if (this.Individual != null) // арендатор физ лицо
            {
                return $"{Surname} {Name} {MiddleName}, тлф:{Phone}";
            }
            else
            {
                return $"{Surname} {Name} {MiddleName}, {Legal.NameLiquid}";
            }
        }
        //public string PassportSeries => Individual?.Series ?? "N/A";
        //public string PassportNumber => Individual?.Number ?? "N/A";
        //public string DateOfIssue => Individual?.Date ?? "N/A";
        //public string IssuedBy => Individual?.IssuedBy ?? "N/A";

        //public string NameLiquid => Legal?.NameLiquid ?? "N/A";
        //public string Street => Legal?.Street.Name ?? "N/A";
        //public string INN => Legal?.INN ?? "N/A";
        //public string Bank => Legal?.Bank.Name ?? "N/A";
        //public string District => Legal?.District.Name ?? "N/A";
        //public int? BuildingNumber => Legal?.BuildingNumber;
        //public int? Housing => Legal?.Housing;
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
    [Table("PremisesContract")]
    public class ContractPremises
    {
        [Key]
        public int ID { get; set; }
        [Column("id_premises")]
        [ForeignKey(nameof(Premises))]
        public int PremisesID { get; set; }
        public Premises Premises { get; set; }

        [Column("id_contract")]
        [ForeignKey(nameof(Contract))]
        public int ContractID { get; set; }
        public Contract Contract { get; set; }

        [Column("id_rent_purpose")]
        [ForeignKey(nameof(RentPurpose))]
        public int RentPurposeID { get; set; }
        public RentPurpose RentPurpose { get; set; }

        [Column("rental_period")]
        public int RentalPeriod { get; set; }
        [Column("rent")]
        public int Rent { get; set; }

        public ContractPremises() { }
        public ContractPremises(Premises premises, Contract contract, RentPurpose rentPurpose, int rentalPeriod, int rent)
        {
            Premises = premises;
            Contract = contract;
            RentPurpose = rentPurpose;
            RentalPeriod = rentalPeriod;
            Rent = rent;
        }
        public string FullAddress => Premises.ToString() ?? "N/A";
        //public string RentPurposeName => RentPurpose.Name ?? "N/A";
    }
    [Table("Contract")]
    public class Contract
    {
        [Key]
        public int ID { get; set; }
        [Column("contract_number")]
        public int ContractNumber { get; set; }
        [Column("start_date")]
        public string StartDate { get; set; }
        [Column("end_date")]
        public string EndDate { get; set; }
        [Column("comments")]
        public string? Comments { get; set; }
        [Column("penalty")]
        public int Penalty { get; set; }

        [Column("id_rentor")]
        [ForeignKey(nameof(Rentor))]
        public int RentorID { get; set; }
        public Rentor Rentor { get; set; }

        [Column("id_payment_frequency")]
        [ForeignKey(nameof(PaymentFrequency))]
        public int PaymentFrequencyID { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public Contract() { }
        public Contract(int contractnumber, string start, string end, string? comment, int penalty, Rentor rentor, PaymentFrequency frequency)
        {
            ContractNumber = contractnumber;
            StartDate = start;
            EndDate = end;
            Comments = comment;
            Penalty = penalty;
            Rentor = rentor;
            PaymentFrequency = frequency;
        }
        public override string ToString()
        {
            return $"№{ContractNumber}";
        }
        //public string RentorName => Rentor.ToString() ?? "N/A";
        //public string PaymentFrequencyName => PaymentFrequency.Name.ToString() ?? "N/A";
    }
}
