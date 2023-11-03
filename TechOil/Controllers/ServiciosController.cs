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
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService _serviciosService;
        public ServiciosController(IServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var servicios = await _serviciosService.GetAll();
            if (servicios?.Count() == 0)
            {
                return NotFound("No se encontraron Servicios");
            }
            else
            {
                return Ok(servicios);
            }
        }
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var servicio = await _serviciosService.GetById(id);
            if (servicio == null)
            {
                return NotFound("No se encontro el servicio solicitado");
            }
            else
            {
                return Ok(servicio);
            }
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] Servicio servicio)
        {
            await _serviciosService.Add(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.CodServicio }, servicio);
        }
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Servicio updateServicio)
        {
            var servicio = await _serviciosService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            servicio.Descr = updateServicio.Descr;
            servicio.ValorHora = updateServicio.ValorHora;
            servicio.Estado= updateServicio.Estado;
            await _serviciosService.Update(servicio);
            return Ok(servicio);
        }
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = await _serviciosService.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            await _serviciosService.Delete(id);
            return Ok("Servicio eliminado satisfactoriamente");
        }
    }
}
