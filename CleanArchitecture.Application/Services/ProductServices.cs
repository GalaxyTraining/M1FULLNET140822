using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services
{
    public class ProductServices: IProductServices
    {
        protected IProductRepository _productRepository;
        public ProductServices(DbContext context)
        {
            _productRepository = new ProductRepository(context);
        }
        public async Task<List<Producto>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }
        public async Task<Producto> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }
        public async Task<int> InsetProduct(Producto product)
        {
            return await _productRepository.Insert(product);
        }
        public async Task<bool> UpdateProduct(Producto product)
        {
            return await _productRepository.Update(product);
        }
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
