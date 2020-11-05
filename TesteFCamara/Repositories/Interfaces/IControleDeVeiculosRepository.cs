using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Repositories.Interfaces
{
    public interface IControleDeVeiculosRepository
    {
        Task RegistrarEntrada(ControleDeVeiculo controleDeVeiculos);
        Task RegistrarSaida(Saida saida);

        Task<IEnumerable<ControleDeVeiculo>> BuscarVeiculo(int id);
    }
}