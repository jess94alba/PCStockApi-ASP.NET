using PCStockApi.Models;
using PCStockApi.Repositories.Interfaces;
using PCStockApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCStockApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenRegistro> CrearTokenAsync(string tipo, string? nitEmpresa = null)
        {
            return await _tokenRepository.CrearTokenAsync(tipo, nitEmpresa);
        }

        public async Task<bool> ValidarTokenAsync(string token)
        {
            return await _tokenRepository.ValidarTokenAsync(token);
        }

        public async Task<IEnumerable<TokenRegistro>> ObtenerTokensAsync()
        {
            return await _tokenRepository.ObtenerTokensAsync();
        }
    }
}
