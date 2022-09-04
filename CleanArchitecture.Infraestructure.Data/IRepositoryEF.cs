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
        Task<T> GetEntityByIdAsync(int id);
        void  Update(T entity);
        void Delete(T entity);
        Task<T> Obtener<T>(Expression<Func<T, bool>> condicion) where T : class;
        void Insert(T entity);

        T GetEntityById(int id);
    }
}
