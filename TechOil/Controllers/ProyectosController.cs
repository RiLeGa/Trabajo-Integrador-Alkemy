using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TechOil.Models;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;
        public ProyectosController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var proyectos = _proyectoRepository.GetAllProyectos();
            if (proyectos?.Count() == 0)
            {
                return NotFound("No se encontraron Servicios");
            }
            else
            {
                return Ok(proyectos);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var proyecto = _proyectoRepository.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound("No se encontro el proyecto solicitado");
            }
            else
            {
                return Ok(proyecto);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Proyecto proyecto) 
        {
            _proyectoRepository.AddProyecto(proyecto);
            return CreatedAtAction(nameof(Get), new {id = proyecto.CodProyecto}, proyecto);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Proyecto updateProyecto) 
        {
            var proyecto = _proyectoRepository.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            proyecto.Nombre = updateProyecto.Nombre;
            proyecto.Direccion = updateProyecto.Direccion;
            proyecto.Estado = updateProyecto.Estado;
            _proyectoRepository.UpdateProyecto(proyecto);
            return Ok(proyecto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var proyecto = _proyectoRepository.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            _proyectoRepository.DeleteProyecto(id);
            return Ok("Proyecto eliminado satisfactoriamente");
        }

       
    }
}
