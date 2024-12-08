using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
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
}
