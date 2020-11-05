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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoServices _estabelecimentoServices;
        public EstabelecimentoController(IEstabelecimentoServices estabelecimentoServices)
        {
            _estabelecimentoServices = estabelecimentoServices;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var estabelecimentos = await _estabelecimentoServices.Listar();
            return Ok(estabelecimentos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] EstabelecimentoRequest estabelecimento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estabelecimentoServices.Cadastrar(estabelecimento.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EstabelecimentoRequest estabelecimento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estabelecimentoServices.Editar(estabelecimento.ToModel());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remover([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estabelecimentoServices.Remover(id);
            return Ok();
        }
    }
}