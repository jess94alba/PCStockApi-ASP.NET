using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.Models;
using PCStockApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<TokenRegistro> CrearTokenAsync(string tipo, string? nitEmpresa = null)
        {
            var token = new TokenRegistro
            {
                Token = Guid.NewGuid().ToString(),
                Tipo = tipo,
                NitEmpresa = nitEmpresa,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddDays(7),
                Usado = false
            };

            _context.TokenRegistros.Add(token);
            await _context.SaveChangesAsync();

            return token;
        }

        public async Task<bool> ValidarTokenAsync(string token)
        {
            var t = await _context.TokenRegistros.FirstOrDefaultAsync(x => x.Token == token);

            if (t == null || t.Usado || (t.FechaExpiracion.HasValue && t.FechaExpiracion < DateTime.UtcNow))
                return false;

            return true;
        }

        public async Task<TokenRegistro?> ObtenerPorTokenAsync(string token) // ✅ agregado
        {
            return await _context.TokenRegistros.FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task MarcarTokenComoUsadoAsync(string token)
        {
            var t = await _context.TokenRegistros.FirstOrDefaultAsync(x => x.Token == token);
            if (t != null)
            {
                t.Usado = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TokenRegistro>> ObtenerTokensAsync()
        {
            return await _context.TokenRegistros.ToListAsync();
        }
    }
}
