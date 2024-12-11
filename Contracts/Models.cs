using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [Table("RentPurpose")]
    public class RentPurpose
    {
        [Key]
        public int ID { get; set; }
        [Column("name")]
        public string Purpose { get; set; }
        public override string ToString()
        {
            return $"{Purpose}";
        }
    }

    [Table("Payment_Frequency")]
    public class PaymentFrequency
    {
        [Key]
        public int ID { get; set; }
        [Column("frequency")]
        public int Frequency { get; set; }
        public override string ToString()
        {
            return $"{Frequency} д.";
        }
    }

    [Table("Street")]
    public class Street
    {
        [Key]
        public int ID { get; set; }
        [Column("street")]
        public string Name { get; set; }
    }

    [Table("District")]
    public class District
    {
        [Key]
        public int ID { get; set; }
        [Column("district")]
        public string Name { get; set; }
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
        public override string ToString()
        {
            return $"{Surname} {Name} {MiddleName}, тлф:{Phone}";
        }
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
        public string RentPurposeName => RentPurpose.Purpose ?? "N/A";
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

        public string RentorName => Rentor.ToString() ?? "N/A";
        public string PaymentFrequencyName => PaymentFrequency.Frequency.ToString() ?? "N/A";
    }
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
