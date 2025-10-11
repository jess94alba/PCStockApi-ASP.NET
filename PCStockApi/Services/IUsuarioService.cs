using PCStockApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCStockApi.Services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Registra un nuevo usuario aplicando las reglas de negocio.
        /// </summary>
        Task<UsuarioDto> RegistrarUsuarioAsync(UsuarioDto dto);

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
    }
}

