using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arenda;
using Microsoft.EntityFrameworkCore;

namespace Contracts
{
    internal class ContractsApplicationContext : ApplicationContext
    {
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Premises> Premises { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<PaymentFrequency> PaymentFrequencies { get; set; }
        public virtual DbSet<RentPurpose> RentPurposes { get; set; }
        public virtual DbSet<Rentor> Rentors { get; set; }
        public virtual DbSet<ContractPremises> ContractPremises { get; set; }
    }
}
