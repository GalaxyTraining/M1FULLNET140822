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
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public void  Insert(Compra compra)
        {
            repositoryEF.Insert(compra);
        }
        public void Update(Compra compra)
        {

        repositoryEF.Update(compra);
        }

        public void UpdateFieldsSave(Compra compra)
        {
            //     public string? NumeroDocumento { get; set; }
            //public string? RazonSocial { get; set; }
            //public decimal? Total { get; set; }
            repositoryEF.UpdateFieldsSave(compra,b=>b.NumeroDocumento,c=>c.RazonSocial,d=>d.Total);
        }
        public void  Delete(int id)
        {
            Compra compra =  repositoryEF.GetEntityById(id);
          repositoryEF.Delete(compra);
        }
    }
}
