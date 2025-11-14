using Microsoft.EntityFrameworkCore;
using PCStockApi.Data;
using PCStockApi.DTOs;
using PCStockApi.Helpers;
using PCStockApi.Models;
using PCStockApi.Repositories.Interfaces;
using PCStockApi.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PCStockApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly ITokenRepository _tokenRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly JwtHelper _jwtHelper;

        public UsuarioService(AppDbContext context, ITokenRepository tokenRepository, IRoleRepository roleRepository, JwtHelper jwtHelper)
        {
            _context = context;
            _tokenRepository = tokenRepository;
            _roleRepository = roleRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<UsuarioDto> RegistrarUsuarioAsync(UsuarioDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Correo))
                throw new Exception("Ya existe un usuario con ese correo.");

            TokenRegistro? token = null;
            if (dto.Rol != "Cliente")
            {
                if (string.IsNullOrEmpty(dto.Token))
                    throw new Exception("Debe ingresar un token válido para registrarse como proveedor o vendedor.");

                token = await _tokenRepository.ObtenerPorTokenAsync(dto.Token);
                if (token == null || token.Usado)
                    throw new Exception("El token no es válido o ya fue usado.");

                if (token.Tipo != dto.Rol)
                    throw new Exception($"El token no corresponde al tipo de usuario '{dto.Rol}'.");
            }

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Correo,
                PasswordHash = HashPassword(dto.Password),
                NitEmpresa = dto.NitEmpresa,
                Telefono = dto.Telefono,
                EsAdmin = dto.Rol == "Administrador",
                FechaRegistro = DateTime.UtcNow,
                TokenUsado = token
            };

            var rol = await _roleRepository.GetByNameAsync(dto.Rol); // ✅ corregido
            if (rol == null)
                throw new Exception($"El rol '{dto.Rol}' no existe en el sistema.");

            usuario.UsuarioRoles.Add(new UsuarioRole
            {
                Usuario = usuario,
                Role = rol
            });

            _context.Usuarios.Add(usuario);

            if (token != null)
            {
                token.Usado = true;
                token.FechaExpiracion = DateTime.UtcNow;
                _context.TokenRegistros.Update(token);
            }

            await _context.SaveChangesAsync();

            return new UsuarioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Correo = usuario.Email,
                Rol = dto.Rol,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public async Task<string> LoginAsync(string correo, string password)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == correo);

            if (usuario == null || !VerifyPassword(password, usuario.PasswordHash))
                throw new Exception("Correo o contraseña incorrectos.");

            var roles = usuario.UsuarioRoles.Select(r => r.Role.Nombre).ToList();
            return _jwtHelper.GenerateJwtToken(usuario.Email, roles);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync() // ✅ agregado
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();

            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.UsuarioId,
                Nombre = u.Nombre,
                Correo = u.Email,
                Rol = string.Join(", ", u.UsuarioRoles.Select(r => r.Role.Nombre)),
                FechaRegistro = u.FechaRegistro
            });
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hash;
        }
    }
}
