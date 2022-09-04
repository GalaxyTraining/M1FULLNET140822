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
    public class ProductRepository:RepositoryEF<Producto>,IProductRepository
    {
       // protected BDEmpresaContext _context;
        public ProductRepository(DbContext context):base(context)
        {
            repositoryEF = new RepositoryEF<Producto>(context);
        }
        public IRepositoryEF<Producto> repositoryEF { get; set; }
        public async Task<List<Producto>> GetProducts()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<Producto> GetProductById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public void Insert(Producto producto)
        {
              repositoryEF.Insert(producto);
        }
        public void  Update(Producto producto)
        {
            repositoryEF.Update(producto);
        }
        public void  Delete(int id)
        {
            Producto producto =  repositoryEF.GetEntityById(id);
            repositoryEF.Delete(producto);
        }
    }
}
