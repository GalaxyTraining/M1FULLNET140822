using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services
{
    public class DetalleCompraServices: IDetalleCompraServices
    {
        protected IDetalleCompraRepository _detalleCompraRepository;

        protected readonly string _connectionString;
        public DetalleCompraServices(DbContext context,string connectionString)
        {
            _connectionString = connectionString;
            _detalleCompraRepository = new DetalleCompraRepository(context, _connectionString);
        }
        public async Task<List<DetalleCompra>> GetAll()
        {
            return await _detalleCompraRepository.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await _detalleCompraRepository.GetById(id);
        }

        public async Task<DetalleCompra> GetByOrderSecuenciaCompra(int? orderSecuencia,int? IdCompra)
        {

            return await _detalleCompraRepository.GetByOrderSecuenciaCompra(orderSecuencia, IdCompra);
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
        public async Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra)
        {
            return await _detalleCompraRepository.ObtenerDetalleCompra(idCompra);
        }
    }
}
