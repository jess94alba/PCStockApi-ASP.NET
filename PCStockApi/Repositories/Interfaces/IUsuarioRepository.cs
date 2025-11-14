using PCStockApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCStockApi.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddUsuarioRoleAsync(long usuarioId, long roleId);
    }
}
