using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Services.Interfaces
{
    public interface IEstabelecimentoServices
    {
        Task<IEnumerable<Estabelecimento>> Listar();
        Task Cadastrar(Estabelecimento estabelecimento);
        Task Editar(Estabelecimento estabelecimento);
        Task Remover(int id);
        
    }
    
}