using AcademyG.Week6.TestFinale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.EF.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CodiceCliente)                
                .IsRequired()
                .HasMaxLength(10);
            builder.
                HasIndex(c => c.CodiceCliente).IsUnique();

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
              .HasMany(c => c.Ordini)
              .WithOne(o => o.Cliente);


        }
    }
}
