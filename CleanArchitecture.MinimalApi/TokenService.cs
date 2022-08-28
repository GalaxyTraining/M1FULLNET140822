using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.MinimalApi
{
    public class TokenService: ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string BuildToken(Usuario usuarios)
        {
            return string.Empty;
        }
    }
}
