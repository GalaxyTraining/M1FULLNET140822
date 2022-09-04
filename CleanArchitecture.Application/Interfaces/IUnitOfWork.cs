using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductServices productServices { get; }

        IUsuarioServices usuarioServices { get; }

        ICompraServices compraServices { get; }
        IDetalleCompraServices detalleCompraServices { get;}
        Task<int> CommitAsync();


    }
}
