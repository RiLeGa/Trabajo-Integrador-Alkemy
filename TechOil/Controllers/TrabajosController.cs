using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajosController : ControllerBase
    {
        private readonly ITrabajoRepository _trabajoRepository;
        public TrabajosController(ITrabajoRepository trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trabajos = _trabajoRepository.GetAllTrabajos();
            if (trabajos?.Count() == 0)
            {
                return NotFound("No se encontraron Trabajos");
            }
            else
            {
                return Ok(trabajos);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trabajo = _trabajoRepository.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound("No se encontro el Trabajo solicitado");
            }
            else
            {
                return Ok(trabajo);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Trabajo trabajo)
        {
            _trabajoRepository.AddTrabajo(trabajo);
            return CreatedAtAction(nameof(Get), new { id = trabajo.CodTrabajo }, trabajo);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Trabajo updateTrabajo)
        {
            var trabajo = _trabajoRepository.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            _trabajoRepository.UpdateTrabajo(trabajo);
            return Ok(trabajo);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trabajo = _trabajoRepository.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            _trabajoRepository.DeleteTrabajo(id);
            return Ok("Trabajo eliminado satisfactoriamente");
        }
    }
}