using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Producto>> GetProducts();
        Task<Producto> GetProductById(int id);

       void  Insert(Producto product);

        void  Update(Producto product);

       void  Delete(int id);
    }
}
