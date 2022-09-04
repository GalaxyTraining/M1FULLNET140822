using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Context.Mapping
{
    public class CompraEntityTypeConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {

            builder.ToTable("Compra");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                 .IsRequired()
               .UseIdentityColumn();
            builder.Property(e => e.NumeroDocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

            builder.Property(e => e.RazonSocial)
                    .HasMaxLength(60)
                    .IsUnicode(false);

            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            
        }
    }
}
