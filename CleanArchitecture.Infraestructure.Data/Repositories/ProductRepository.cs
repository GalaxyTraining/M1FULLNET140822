using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class ProductRepository:IProductRepository
    {
        protected BDEmpresaContext _context;
        public ProductRepository(BDEmpresaContext context)
        {
            _context=context;
        }
        public async Task<List<Producto>> GetProducts()
        {
            return await _context.Producto.ToListAsync();
        }
        public async Task<Producto> GetProductById(int id)
        {
            return await _context.Producto.FindAsync(id);
        }
        public async Task<int> Insert(Producto product)
        {
            await _context.Producto.AddAsync(product);
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> Update(Producto product)
        {
             _context.Update(product);
            return await _context.SaveChangesAsync()>0;
        }
        public async Task<bool> Delete(int id)
        {
            Producto product = new Producto { Id = id };
           _context.Entry(product).State = EntityState.Deleted;
            return await _context.SaveChangesAsync()>0;
        }
    }
}
