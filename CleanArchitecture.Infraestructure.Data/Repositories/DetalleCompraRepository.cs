using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class DetalleCompraRepository : RepositoryEF<DetalleCompra>, IDetalleCompraRepository
    {
        public DetalleCompraRepository(DbContext context) : base(context)
        {
            repositoryEF = new RepositoryEF<DetalleCompra>(context);
        }
        public IRepositoryEF<DetalleCompra> repositoryEF { get; set; }

        public async Task<List<DetalleCompra>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public void Insert(DetalleCompra compra)
        {
            repositoryEF.Insert(compra);
        }
        public void Update(DetalleCompra compra)
        {
            repositoryEF.Update(compra);
        }
        public void Delete(int id)
        {
            DetalleCompra compra = repositoryEF.GetEntityById(id);
            repositoryEF.Delete(compra);
        }
    }
}
