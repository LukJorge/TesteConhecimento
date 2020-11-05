using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFCamara.Services.Interfaces;
using TesteFCamara.Models;
using TesteFCamara.Models.Requests;

namespace TesteFCamara.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ControleDeVeiculosController : ControllerBase
	{
		private readonly IControleDeVeiculosServices _controleDeVeiculosServices;
		public ControleDeVeiculosController(IControleDeVeiculosServices controleDeVeiculosServices)
		{
			_controleDeVeiculosServices = controleDeVeiculosServices;
		}

		[HttpPost]
		public async Task<IActionResult> Entrada([FromBody] ControleDeVeiculoRequest controleDeVeiculos)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _controleDeVeiculosServices.RegistrarEntrada(controleDeVeiculos.ToModel());

			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Saida([FromBody] SaidaRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _controleDeVeiculosServices.RegistrarSaida(request.ToModel());

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> BuscarVeiculo(int id)
		{
			var veiculo = await _controleDeVeiculosServices.BuscarVeiculo(id);
			return Ok(veiculo);
		}

	}
}