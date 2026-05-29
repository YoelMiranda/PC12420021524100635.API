using Microsoft.AspNetCore.Mvc;
using PC12420021524100635.CORE.Core.DTOs;
using PC12420021524100635.CORE.Core.Interfaces;

namespace PC12420021524100635.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioService _ordenServicioService;

        public OrdenServicioController(IOrdenServicioService ordenServicioService)
        {
            _ordenServicioService = ordenServicioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordenes = await _ordenServicioService.GetAll();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orden = await _ordenServicioService.GetById(id);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdenServicioCreateDTO createDTO)
        {
            if (createDTO == null) return BadRequest();
            await _ordenServicioService.Create(createDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenServicioUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id) return BadRequest();
            var existing = await _ordenServicioService.GetById(id);
            if (existing == null) return NotFound();
            await _ordenServicioService.Update(updateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _ordenServicioService.GetById(id);
            if (existing == null) return NotFound();
            await _ordenServicioService.Delete(id);
            return NoContent();
        }
    }
}
