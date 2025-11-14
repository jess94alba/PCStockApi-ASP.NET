using PCStockApi.Models;
using System.Threading.Tasks;

namespace PCStockApi.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleName?> GetByNameAsync(string roleName);
    }
}
