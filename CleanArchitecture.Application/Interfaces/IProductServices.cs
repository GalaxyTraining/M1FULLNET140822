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
        void  InsertProduct(Producto product);
        void UpdateProduct(Producto product);

        void DeleteProduct(int id);
    }
}
