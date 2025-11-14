using PCStockApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCStockApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenRegistro> CrearTokenAsync(string tipo, string? nitEmpresa = null);
        Task<bool> ValidarTokenAsync(string token);
        Task<IEnumerable<TokenRegistro>> ObtenerTokensAsync();
    }
}
