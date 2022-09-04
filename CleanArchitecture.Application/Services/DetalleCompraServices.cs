using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services
{
    public class DetalleCompraServices: IDetalleCompraServices
    {
        protected IDetalleCompraRepository _detalleCompraRepository;
        public DetalleCompraServices(DbContext context)
        {
            _detalleCompraRepository = new DetalleCompraRepository(context);
        }
        public async Task<List<DetalleCompra>> GetAll()
        {
            return await _detalleCompraRepository.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await _detalleCompraRepository.GetById(id);
        }
        public void Insert(DetalleCompra detalleCompra)
        {
            _detalleCompraRepository.Insert(detalleCompra);
        }
        public void Update(DetalleCompra detalleCompra)
        {
            _detalleCompraRepository.Update(detalleCompra);
        }
        public void Delete(int id)
        {
            _detalleCompraRepository.Delete(id);
        }
    }
}
