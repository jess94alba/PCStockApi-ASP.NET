using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.Models;
using System.Threading.Tasks;

namespace PCStockApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RoleName?> GetByNameAsync(string roleName)
        {
            return await _context.RoleNames
                .FirstOrDefaultAsync(r => r.Nombre.ToLower() == roleName.ToLower());
        }
    }
}
