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
    public class DetalleCompraEntityTypeConfiguration : IEntityTypeConfiguration<DetalleCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleCompra> builder)
        {

            builder.ToTable("DetalleCompra");

            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.Producto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_IdVenta");
          
        }
    }
}
