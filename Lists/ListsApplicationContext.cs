using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arenda;

namespace Lists
{
    public partial class ListsApplicationContext : ApplicationContext
    {
        public virtual DbSet<Bank> Banks { get; set; } = null;
        public virtual DbSet<Decoration> Decorations { get; set; } = null;
        public virtual DbSet<District> Districts{ get; set; } = null;
        public virtual DbSet<PaymentFrequency> PaymentFrequencies{ get; set; } = null;
        public virtual DbSet<RentPurpose> RentPurpose{ get; set; } = null;
        public virtual DbSet<Street> Streets{ get; set; } = null;
    }
}
