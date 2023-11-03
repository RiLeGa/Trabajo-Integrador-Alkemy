using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net.WebSockets;
using TechOil.Models;
using TechOil.Models.Dtos;
using TechOil.Repositorys;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectosService _proyectoService;
        public readonly IMapper _mapper;
        public ProyectosController(IProyectosService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var proyectos = await _proyectoService.GetAll();
            if (proyectos?.Count() == 0)
            {
                return NotFound("No se encontraron Proyectos");
            }
            else
            {
                return Ok(proyectos);
                //var proyectosDTOs = _mapper.Map<List<ProyectosDto>>(proyectos);
                //return Ok(proyectosDTOs); 
            }
        }
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var proyecto = await _proyectoService.GetById(id);
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
        //[Authorize]
        public async Task<IActionResult> Post([FromBody]Proyecto proyecto) 
        {
            await _proyectoService.Add(proyecto);
            return CreatedAtAction(nameof(Get), new {id = proyecto.CodProyecto}, proyecto);
        }
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, [FromBody]Proyecto updateProyecto) 
        {
            var proyecto = await _proyectoService.GetById(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            proyecto.Nombre = updateProyecto.Nombre;
            proyecto.Direccion = updateProyecto.Direccion;
            proyecto.Estado = updateProyecto.Estado;
            await _proyectoService.Update(proyecto);
            return Ok(proyecto);
        }
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id) 
        {
            var proyecto = await _proyectoService.GetById(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            await _proyectoService.Delete(id);
            return Ok("Proyecto eliminado satisfactoriamente");
        }

       
    }
}
