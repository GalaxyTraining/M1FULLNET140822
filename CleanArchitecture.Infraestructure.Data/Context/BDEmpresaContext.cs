using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Models;
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

        public virtual DbSet<Producto> Producto { get; set; } = null!;

    }
}
