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
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioService.GetAll();
            if (usuarios?.Count() == 0)
            {
                return NotFound("No se encontraron usuarios");
            }
            else
            {
                //var usuariosDTOs = _mapper.Map<List<UsuariosDto>>(usuarios);
                return Ok(usuarios);
            }
        }
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioService.GetById(id);
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
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.CodUsuario }, usuario);
        }
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] UsuariosDto updateUsuario)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre= updateUsuario.Nombre;
            await _usuarioService.Update(usuario);
            return Ok("Ususario modificado");
        }
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await _usuarioService.Delete(id);
            return Ok("Usuario eliminado satisfactoriamente");
        }
    }
}
