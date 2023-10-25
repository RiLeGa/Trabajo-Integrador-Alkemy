using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.Dtos;
using TechOil.Repositorys;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;
        public readonly IMapper _mapper;
        public UsuariosController(IUsuariosService usuariosService, IMapper mapper)
        {
            _usuarioService = usuariosService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.GetAll();
            if (usuarios?.Count() == 0)
            {
                return NotFound("No se encontraron usuarios");
            }
            else
            {
                //return Ok(usuarios);
                var usuariosDTOs = _mapper.Map<List<UsuariosDto>>(usuarios);
                return Ok(usuariosDTOs);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound("No se encontro el Usuario solicitado");
            }
            else
            {
                return Ok(usuario);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.CodUsuario }, usuario);
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Usuario updateUsuario)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre= updateUsuario.Nombre;
            usuario.Dni= updateUsuario.Dni;
            usuario.Tipo= updateUsuario.Tipo;
            _usuarioService.Update(usuario);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioService.Delete(id);
            return Ok("Usuario eliminado satisfactoriamente");
        }
    }
}
