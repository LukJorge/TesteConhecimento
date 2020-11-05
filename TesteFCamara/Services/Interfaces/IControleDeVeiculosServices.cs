using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Services.Interfaces
{
    public interface IControleDeVeiculosServices
    {
        Task RegistrarEntrada(ControleDeVeiculo controleDeVeiculos);
        Task RegistrarSaida(Saida saida);

        Task<IEnumerable<ControleDeVeiculo>> BuscarVeiculo(int id);
    }
}