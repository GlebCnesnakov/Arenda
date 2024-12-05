using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
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
}
