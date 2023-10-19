using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.GetAllUsuarios();
            if (usuarios?.Count() == 0)
            {
                return NotFound("No se encontraron Usuarios");
            }
            else
            {
                return Ok(usuarios);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioById(id);
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
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.CodUsuario }, usuario);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario updateUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre= updateUsuario.Nombre;
            usuario.Dni= updateUsuario.Dni;
            usuario.Tipo= updateUsuario.Tipo;
            _usuarioRepository.UpdateUsuario(usuario);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioRepository.DeleteUsuario(id);
            return Ok("Usuario eliminado satisfactoriamente");
        }
    }
}
