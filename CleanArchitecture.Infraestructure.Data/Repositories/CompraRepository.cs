using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class CompraRepository : RepositoryEF<Compra>, ICompraRepository
    {
        public CompraRepository(DbContext context) : base(context)
        {
            repositoryEF = new RepositoryEF<Compra>(context);
        }
        public IRepositoryEF<Compra> repositoryEF { get; set; }

        public async Task<List<Compra>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<Compra> GetById(int id)
        {
            return await repositoryEF.GetEntityById(id);
        }
        public async Task<int> Insert(Compra compra)
        {
            return await repositoryEF.Insert(compra);
        }
        public async Task<bool> Update(Compra compra)
        {
            return await repositoryEF.Update(compra);
        }
        public async Task<bool> Delete(int id)
        {
            Compra compra = await repositoryEF.GetEntityById(id);
            return await repositoryEF.Delete(compra);
        }
    }
}
