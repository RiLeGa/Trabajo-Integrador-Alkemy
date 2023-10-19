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
        private readonly IServicioRepository _servicioRepository;
        public ServiciosController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var servicios = _servicioRepository.GetAllServicios();
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
        public IActionResult Get(int id)
        {
            var servicio = _servicioRepository.GetServicioById(id);
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
        public IActionResult Post([FromBody] Servicio servicio)
        {
            _servicioRepository.AddServicio(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.CodServicio }, servicio);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Servicio updateServicio)
        {
            var servicio = _servicioRepository.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            servicio.Descr = updateServicio.Descr;
            servicio.ValorHora = updateServicio.ValorHora;
            servicio.Estado= updateServicio.Estado;
            _servicioRepository.UpdateServicio(servicio);
            return Ok(servicio);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servicio = _servicioRepository.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            _servicioRepository.DeleteServicio(id);
            return Ok("Servicio eliminado satisfactoriamente");
        }
    }
}
