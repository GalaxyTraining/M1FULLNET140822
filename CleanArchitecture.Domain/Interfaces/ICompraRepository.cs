using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICompraRepository
    {
        Task<List<Compra>> GetAll();

        Task<Compra> GetById(int id);

        void Insert(Compra compra);

        void Update(Compra compra);

        void Delete(int id);

        void UpdateFieldsSave(Compra compra);

        Task<List<Compra>> listaBusquedaCompra(string numeroDocumento, string razonSocial);
    }
}
