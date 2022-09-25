using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BDEmpresaContext _context;
        protected readonly string _connectionString;
        public UnitOfWork(BDEmpresaContext context, string connectionString)
        {
            _context = context;
            productServices = new ProductServices(context);
            usuarioServices = new UsuarioServices(context);
            compraServices = new CompraServices(context);
            _connectionString = connectionString;
            detalleCompraServices = new DetalleCompraServices(context, _connectionString);
        }
        public IProductServices productServices { get; private set; }

        public IUsuarioServices usuarioServices { get; private set; }

        public ICompraServices compraServices { get; private set; }

        public IDetalleCompraServices detalleCompraServices { get; private set; }
        public async Task<int> CommitAsync()
        {
            return await  _context.SaveChangesAsync();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
    }
}
