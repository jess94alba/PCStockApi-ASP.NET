using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.Models;

namespace PCStockApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
