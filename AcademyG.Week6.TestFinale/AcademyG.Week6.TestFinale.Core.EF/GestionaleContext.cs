using AcademyG.Week6.TestFinale.Core.EF.Configurations;
using AcademyG.Week6.TestFinale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.EF
{
    public class GestionaleContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        
        public GestionaleContext() : base() { }
        public GestionaleContext(DbContextOptions<GestionaleContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {                
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Gestionale;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
        }

    }
}
