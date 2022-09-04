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
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuario");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnName("Id")
            .UseIdentityColumn();
            builder.Property(e => e.Clave)
                    .HasMaxLength(200)
                    .IsUnicode(false);

            builder.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

            builder.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            
        }
    }
}
