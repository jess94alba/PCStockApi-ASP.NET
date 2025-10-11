using PCStockApi.Models;
using System.Threading.Tasks;

namespace PCStockApi.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleName?> GetByNameAsync(string roleName);
    }
}
