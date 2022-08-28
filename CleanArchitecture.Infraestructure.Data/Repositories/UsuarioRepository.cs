using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class UsuarioRepository:RepositoryEF<Usuario>,IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
            repositoryEF = new RepositoryEF<Usuario>(context);
        }
        public IRepositoryEF<Usuario> repositoryEF { get; set; }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            Usuario resultado = await repositoryEF.Obtener<Usuario>(a => a.Nombre == usuario.Nombre && a.Clave == usuario.Clave);
            return resultado;
        }
    }
}
