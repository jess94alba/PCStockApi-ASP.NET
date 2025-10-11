using BCrypt.Net;
using PCStockApi.DTOs;
using PCStockApi.Mappers;
using PCStockApi.Repositories;

namespace PCStockApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> RegistrarUsuarioAsync(UsuarioDto dto)
        {
            // 1️⃣ Validaciones
            if (dto.Rol == "Administrador")
                throw new InvalidOperationException("No se puede registrar un Administrador desde el API.");

            if ((dto.Rol == "Proveedor" || dto.Rol == "Vendedor") && string.IsNullOrEmpty(dto.Token))
                throw new InvalidOperationException("Se requiere un token otorgado por el administrador.");

            // 2️⃣ Validar correo existente
            var existente = await _usuarioRepository.GetByEmailAsync(dto.Correo);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un usuario con este correo.");

            // 3️⃣ Cifrar contraseña
            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // 4️⃣ Guardar en BD
            var usuario = UsuarioMapper.ToEntity(dto);
            await _usuarioRepository.AddAsync(usuario);

            return UsuarioMapper.ToDto(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(u => UsuarioMapper.ToDto(u));
        }
    }
}
