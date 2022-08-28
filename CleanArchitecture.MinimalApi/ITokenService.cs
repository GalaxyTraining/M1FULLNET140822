using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.MinimalApi
{
    public interface ITokenService
    {
        string BuildToken(Usuario usuarios);
    }
}
