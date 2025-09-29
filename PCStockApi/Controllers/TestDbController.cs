using Microsoft.AspNetCore.Mvc;
using PCStockApi.Data;

namespace PCStockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestDbController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestDbController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            try
            {
                // Solo verificamos que pueda conectarse
                _context.Database.CanConnect();
                return Ok("Conexión a la BD exitosa");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al conectar con la BD: {ex.Message}");
            }
        }
    }
}
