using Microsoft.AspNetCore.Mvc;
using PCStockApi.DTOs;
using PCStockApi.Services;
using System;
using System.Threading.Tasks;

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

        // ✅ POST: api/usuario/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var nuevoUsuario = await _usuarioService.RegistrarUsuarioAsync(dto);
                return CreatedAtAction(nameof(ObtenerUsuarios), new { id = nuevoUsuario.Id }, nuevoUsuario);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }

        // ✅ GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener usuarios", error = ex.Message });
            }
        }
    }
}
