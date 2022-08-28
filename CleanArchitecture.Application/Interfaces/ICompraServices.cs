using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICompraServices
    {
        Task<List<Compra>> GetAll();

        Task<Compra> GetById(int id);

        Task<int> Insert(Compra product);

        Task<bool> UpdateProduct(Compra product);

        Task<bool> DeleteProduct(int id);
    }
}
