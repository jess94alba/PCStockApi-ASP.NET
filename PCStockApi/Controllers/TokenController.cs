using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStockApi.Models;
using PCStockApi.Services.Interfaces;

namespace PCStockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")] // Solo el admin puede usar estos endpoints
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // 🔹 POST: /api/token/generar
        [HttpPost("generar")]
        public async Task<IActionResult> GenerarToken([FromQuery] string tipo, [FromQuery] string? nitEmpresa = null)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                return BadRequest(new { mensaje = "Debe especificar el tipo de token (Proveedor o Vendedor)." });

            try
            {
                var token = await _tokenService.CrearTokenAsync(tipo, nitEmpresa);
                return Ok(new
                {
                    mensaje = $"Token generado exitosamente para tipo '{tipo}'.",
                    token = token.Token,
                    expiracion = token.FechaExpiracion
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // 🔹 GET: /api/token/listar
        [HttpGet("listar")]
        public async Task<IActionResult> ObtenerTokens()
        {
            try
            {
                var tokens = await _tokenService.ObtenerTokensAsync();
                return Ok(new
                {
                    mensaje = "Lista de tokens obtenida correctamente.",
                    total = tokens.Count(),
                    tokens
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // 🔹 GET: /api/token/validar/{token}
        [HttpGet("validar/{token}")]
        [AllowAnonymous] // puede usarse sin autenticación
        public async Task<IActionResult> ValidarToken(string token)
        {
            try
            {
                bool esValido = await _tokenService.ValidarTokenAsync(token);
                return Ok(new
                {
                    token,
                    valido = esValido
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
