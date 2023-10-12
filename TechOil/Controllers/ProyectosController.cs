using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(proyectos);
        }

       
    }
}
