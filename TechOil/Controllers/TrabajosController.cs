using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Repositorys;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajosController : ControllerBase
    {
        private readonly ITrabajosService _trabajoService;
        public TrabajosController(ITrabajosService trabajoService)
        {
            _trabajoService = trabajoService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var trabajos = await _trabajoService.GetAll();
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
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var trabajo = await _trabajoService.GetById(id);
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
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] Trabajo trabajo)
        {
            await _trabajoService.Add(trabajo);
            return CreatedAtAction(nameof(Get), new { id = trabajo.CodTrabajo }, trabajo);
        }
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Trabajo updateTrabajo)
        {
            var trabajo = await _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            trabajo.CodProyecto = updateTrabajo.CodProyecto;
            trabajo.CodServicio = updateTrabajo.CodServicio;
            trabajo.CantHoras = updateTrabajo.CantHoras;
            await _trabajoService.Update(trabajo);
            return Ok(trabajo);
        }
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var trabajo = await _trabajoService.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            await _trabajoService.Delete(id);
            return Ok("Trabajo eliminado satisfactoriamente");
        }
    }
}