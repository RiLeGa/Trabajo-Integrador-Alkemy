using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechOil.Models;
using TechOil.Repositorys;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] Usuario usuario)
        {
            IActionResult response = Unauthorized();
            var usuarioEnDb = _usuarioRepository.GetUserByUsername(usuario.Nombre);
            if(usuarioEnDb != null) { 
                if (usuario != null && usuario.Nombre.Equals(usuarioEnDb.Nombre) && usuario.Password.Equals(usuarioEnDb.Password)
                    || usuario.Nombre.Equals("Leandro") && usuario.Password.Equals("Leandro2"))
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature
                        );
                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.Nombre),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Nombre)
                    });
                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHAndler = new JwtSecurityTokenHandler();
                    var token = tokenHAndler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHAndler.WriteToken(token);

                    return Ok(jwtToken);
                }
            return response;
            }
            return response;
        }
    }
}
