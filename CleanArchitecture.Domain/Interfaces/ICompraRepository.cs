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

        Task<int> Insert(Compra compra);

        Task<bool> Update(Compra compra);

        Task<bool> Delete(int id);

    }
}
