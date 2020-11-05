using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFCamara.Models;
using TesteFCamara.Models.Requests;
using TesteFCamara.Services.Interfaces;

namespace TesteFCamara.Controllers
{   
    [ApiController]
    [Route("[controller]/[action]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServices _veiculoServices;
        public VeiculoController(IVeiculoServices veiculoServices)
        {
            _veiculoServices = veiculoServices;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var veiculos = await _veiculoServices.Listar();
            return Ok(veiculos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] VeiculoRequest veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _veiculoServices.Cadastrar(veiculo.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] VeiculoRequest veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _veiculoServices.Editar(veiculo.ToModel());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _veiculoServices.Remover(id);
            return Ok();
        }
        
    }
}