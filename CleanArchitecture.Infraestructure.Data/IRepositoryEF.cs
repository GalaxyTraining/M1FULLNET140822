using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data
{
    public interface IRepositoryEF<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetEntityById(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Obtener<T>(Expression<Func<T, bool>> condicion) where T : class;
        Task<int> Insert(T entity);
    }
}
