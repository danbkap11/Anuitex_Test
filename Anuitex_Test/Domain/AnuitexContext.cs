using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Anuitex_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Anuitex_Test.Domain
{
    class AnuitexContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Brigadier> Brigadiers { get; set; }
        
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=(localdb)\mssqllocaldb;Database=Anuitex;Trusted_Connection=True;");
        }
    }
}

