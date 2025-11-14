using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStockApi.DTOs;
using PCStockApi.Services.Interfaces;

namespace PCStockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // 🔹 POST: /api/usuario/registro
        [HttpPost("registro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] UsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { mensaje = "Datos inválidos." });

            try
            {
                var usuario = await _usuarioService.RegistrarUsuarioAsync(dto);
                return Ok(new
                {
                    mensaje = "Usuario registrado exitosamente.",
                    usuario
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // 🔹 POST: /api/usuario/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Correo) || string.IsNullOrEmpty(dto.Password))
                return BadRequest(new { mensaje = "Debe ingresar correo y contraseña." });

            try
            {
                var token = await _usuarioService.LoginAsync(dto.Correo, dto.Password);
                return Ok(new
                {
                    mensaje = "Inicio de sesión exitoso.",
                    token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensaje = ex.Message });
            }
        }

        // 🔹 GET: /api/usuario/listar
        [HttpGet("listar")]
        [Authorize(Roles = "Administrador")] // Solo el admin puede ver todos
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosAsync();
                return Ok(new
                {
                    mensaje = "Lista de usuarios obtenida correctamente.",
                    total = usuarios.Count(),
                    usuarios
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}

