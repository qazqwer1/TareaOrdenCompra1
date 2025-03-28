using Microsoft.AspNetCore.Mvc;
using Tarea.DTO;
using Tarea.Modelos;
using Tarea.Servicios;

namespace Tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenesController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orden = await _ordenService.ObtenerPorId(id);
            if (orden == null) return NotFound();

            var dto = _ordenService.MapearADto(orden);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _ordenService.ObtenerPaginado(page, pageSize);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdenCompraCreateDto dto)
        {
            var orden = await _ordenService.CrearDesdeDto(dto);
            var respuesta = _ordenService.MapearADto(orden);
            return CreatedAtAction(nameof(Get), new { id = orden.Id }, respuesta);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _ordenService.Eliminar(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenCompraUpdateDto dto)
        {
            var actualizada = await _ordenService.Actualizar(id, dto);
            if (actualizada == null)
                return NotFound();

            var dtoRespuesta = _ordenService.MapearADto(actualizada);
            return Ok(dtoRespuesta);
        }


    }
}
