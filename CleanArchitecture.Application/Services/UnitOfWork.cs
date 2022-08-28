using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork(BDEmpresaContext context)
        {
            productServices = new ProductServices(context);
            usuarioServices = new UsuarioServices(context);
        }
        public IProductServices productServices { get; private set; }

        public IUsuarioServices usuarioServices { get; private set; }
    }
}
