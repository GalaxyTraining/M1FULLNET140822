using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductServices
    {
        Task<List<Producto>> GetProducts();
        Task<Producto> GetProductById(int id);
        Task<int> InsetProduct(Producto product);
        Task<bool> UpdateProduct(Producto product);

        Task<bool> DeleteProduct(int id);
    }
}
