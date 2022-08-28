using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
