using AcademyG.Week6.TestFinale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.EF.Configurations
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
               .Property(o => o.DataOrdine)
               .IsRequired();

            builder
                .Property(o => o.CodiceOrdine)
                .IsRequired()
                .HasMaxLength(20);
            builder.
                HasIndex(o => o.CodiceOrdine).IsUnique();

            builder
                .Property(o => o.CodiceProdotto)
                .IsRequired()
                .HasMaxLength(20);
            builder.
                HasIndex(o => o.CodiceProdotto).IsUnique();

            builder
                .Property(o => o.Importo)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasCheckConstraint(
               "CK_Ordine_Importo",
               "Importo >= 0"
           );

            builder
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordini)
                .HasForeignKey(o => o.ClienteId);
        }
    }
}
