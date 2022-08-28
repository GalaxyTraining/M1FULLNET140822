using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public  class UsuarioServices: IUsuarioServices
    {
        protected IUsuarioRepository _usuarioRepository;
        public UsuarioServices(DbContext context)
        {
            _usuarioRepository = new UsuarioRepository(context);
        }
        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _usuarioRepository.ValidateUser(usuario);
        }
    }
}
