using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.Models;
using System.Threading.Tasks;

namespace PCStockApi.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _context;

        public TokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidarTokenAsync(string token)
        {
            var tokenValido = await _context.TokenRegistros
                .FirstOrDefaultAsync(t => t.Token == token && t.Usado == false);

            if (tokenValido == null)
                return false;

            // Marcar token como usado
            tokenValido.Usado = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
