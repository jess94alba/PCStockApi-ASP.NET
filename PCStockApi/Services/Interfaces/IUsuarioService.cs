using PCStockApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCStockApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> RegistrarUsuarioAsync(UsuarioDto dto);
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task<string> LoginAsync(string correo, string password);
    }
}
