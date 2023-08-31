using ExemploAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExemploAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class UsuarioController : PrincipalController
	{
		[HttpGet]
		public async Task<IActionResult> Buscar()
		{
			return Ok("Olá mundo, minha primeira requisição GET");
		}

		[HttpGet("ObterPorId/{id}")]
		public async Task<IActionResult> BuscarPorId(int id)
		{
			return Ok($"Olá mundo,exemplo rota com id = {id}");
				
		}

		[HttpPost]
		public async Task<IActionResult> Adicionar(Usuario testeViewModel)
		{
			if(!ModelState.IsValid)
			{
				return ApiBadRequestResponse(ModelState);

			}
			return ApiResponse(testeViewModel,"Registro criado com sucesso!");
		}
	}
}
