using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Contracts
{
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
}
