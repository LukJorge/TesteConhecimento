using TesteFCamara.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;
using TesteFCamara.Services.Interfaces;

namespace TesteFCamara.Services
{
    public class VeiculoServices : IVeiculoServices
    {
         private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoServices(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            return await _veiculoRepository.Listar();
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            await _veiculoRepository.Cadastrar(veiculo);
        }

          public async Task Editar(Veiculo veiculo)
        {
            await _veiculoRepository.Editar(veiculo);
        }

           public async Task Remover(int id )
        {
            await _veiculoRepository.Remover(id);
        }
    }
}