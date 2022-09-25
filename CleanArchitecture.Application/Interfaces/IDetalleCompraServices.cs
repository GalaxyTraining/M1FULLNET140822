using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IDetalleCompraServices
    {
        Task<List<DetalleCompra>> GetAll();

        Task<DetalleCompra> GetById(int id);

        void Insert(DetalleCompra detalleCompra);

        void Update(DetalleCompra detalleCompra);

        void Delete(int id);

        Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra);
    }
}
