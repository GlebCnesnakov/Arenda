using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arenda;
using Microsoft.EntityFrameworkCore;

namespace Documents
{
    internal class DocumentsApplicationContext : ApplicationContext
    {
        public virtual DbSet<Rentor> Rentors { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractPremises> ContractPremises { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Premises> Premises { get; set; }
        public virtual DbSet<Building> Buildings{ get; set; }
    }
}
