using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Services.Interfaces
{
    public interface IVeiculoServices
    {
        Task<IEnumerable<Veiculo>> Listar();
        Task Cadastrar(Veiculo veiculo);
        Task Editar(Veiculo veiculo);
        Task Remover(int id);
        
    }
}