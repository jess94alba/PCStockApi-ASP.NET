using PCStockApi.Models;

namespace PCStockApi.Repositories
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}
