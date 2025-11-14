using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.Models;
using PCStockApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCStockApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        public async Task AddUsuarioRoleAsync(long usuarioId, long roleId)
        {
            var usuarioRole = new UsuarioRole
            {
                UsuarioId = usuarioId,
                RoleId = roleId
            };

            _context.UsuarioRoles.Add(usuarioRole);
            await _context.SaveChangesAsync();
        }
    }
}
