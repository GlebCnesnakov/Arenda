using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arenda;
using Microsoft.EntityFrameworkCore;

namespace Premises
{
    internal class PremisesApplicationContext : ApplicationContext
    {
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Premises> Premises { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Decoration> Decorations { get; set; }
    }
}
