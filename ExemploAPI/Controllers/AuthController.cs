using BCrypt.Net;
using ExemploAPI.Interfaces.Repositorio;
using ExemploAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExemploAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepositorio _authRepositorio;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepositorio authRepositorio, IConfiguration configuration)
        {
            _authRepositorio = authRepositorio;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Usuario>> Cadastrar(Usuario usuario)
        {
            if (!ModelState.IsValid) 
                return BadRequest("Dados inválidos");
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            var result = await _authRepositorio.Cadastrar(usuario);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Usuario>> Login(string usuario, string senha)
        {
            if (!ModelState.IsValid) 
                return BadRequest("Dados inválidos");

            var user = _authRepositorio.BuscarUsuario(usuario);
            if(user == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            
            if(!BCrypt.Net.BCrypt.Verify(user.Senha, senha))
            {
                return BadRequest("Credenciais Inválidas");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
