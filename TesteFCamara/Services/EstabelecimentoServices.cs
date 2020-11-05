using TesteFCamara.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;
using TesteFCamara.Services.Interfaces;

namespace TesteFCamara.Services
{

    public class EstabelecimentoServices : IEstabelecimentoServices
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoServices(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public async Task<IEnumerable<Estabelecimento>> Listar()
        {
            return await _estabelecimentoRepository.Listar();
        }

        public async Task Cadastrar(Estabelecimento estabelecimento)
        {
            await _estabelecimentoRepository.Cadastrar(estabelecimento);
        }

          public async Task Editar(Estabelecimento estabelecimento)
        {
            await _estabelecimentoRepository.Editar(estabelecimento);
        }

           public async Task Remover(int id )
        {
            await _estabelecimentoRepository.Remover(id);
        }
    }
}