using Microsoft.AspNetCore.Mvc;
using Tarea.Modelos;
using Tarea.Servicios;

namespace Tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.ObtenerTodos();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var creado = await _productoService.Crear(producto);
            return CreatedAtAction(nameof(GetAll), new { id = creado.Id }, creado);
        }
    }
}
