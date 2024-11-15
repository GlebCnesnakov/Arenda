using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Arenda
{
    class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MainMenuItem> MainMenuItems { get; set; }
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Database.db"));

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainMenuItem>().Property(p => p.ParrentID).HasColumnName("parrent_id");
            modelBuilder.Entity<MainMenuItem>().Property(p => p.Name).HasColumnName("name");
            modelBuilder.Entity<MainMenuItem>().Property(p => p.Module).HasColumnName("dll_name");
            modelBuilder.Entity<MainMenuItem>().Property(p => p.Method).HasColumnName("function_name");
            modelBuilder.Entity<MainMenuItem>().Property(p => p.Sequence).HasColumnName("sequence");
            modelBuilder.Entity<MainMenuItem>().HasAnnotation("Relational:ConstructorBinding", typeof(MainMenuItem).GetConstructor(new[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int) }));


        }
    }
}
