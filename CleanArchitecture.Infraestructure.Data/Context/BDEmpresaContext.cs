using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitecture.Infraestructure.Data.Context
{
    public partial class BDEmpresaContext : DbContext
    {
        public BDEmpresaContext()
        {
        }

        public BDEmpresaContext(DbContextOptions<BDEmpresaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compra { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source = DESKTOP-0RI6A0M\\MSSQLSERVER01; initial catalog = BDEmpresa; user id = sa; password = 12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CompraEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleCompraEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
