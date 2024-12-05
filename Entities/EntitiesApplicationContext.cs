using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arenda;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    internal class EntitiesApplicationContext : ApplicationContext
    {
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Street> Streets{ get; set; }
        public virtual DbSet<District> Districts{ get; set; }
        public virtual DbSet<Rentor> Rentors{ get; set; }
        public virtual DbSet<Liquid> Liquids{ get; set; }
        public virtual DbSet<Individual> Individuals{ get; set; }

        
    }
}
