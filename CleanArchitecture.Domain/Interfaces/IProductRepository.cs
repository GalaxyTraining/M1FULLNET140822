using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Producto>> GetProducts();
        Task<Producto> GetProductById(int id);

        Task<int> Insert(Producto product);

        Task<bool> Update(Producto product);

        Task<bool> Delete(int id);
    }
}
