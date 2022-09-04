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
    public class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {

            builder.ToTable("Producto");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                 .IsRequired()
               .UseIdentityColumn();
            builder.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
         
        }
    }
}
