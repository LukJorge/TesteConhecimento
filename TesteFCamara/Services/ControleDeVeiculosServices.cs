using System.Threading.Tasks;
using TesteFCamara.Repositories.Interfaces;
using TesteFCamara.Services.Interfaces;
using TesteFCamara.Models;
using System;
using System.Collections.Generic;

namespace TesteFCamara.Services
{
    public class ControleDeVeiculosServices : IControleDeVeiculosServices
    {
        private readonly IControleDeVeiculosRepository _controleDeVeiculosRepository;
        public ControleDeVeiculosServices(IControleDeVeiculosRepository controleDeVeiculosRepository)
        {
            _controleDeVeiculosRepository = controleDeVeiculosRepository;
        }
        public async Task RegistrarEntrada(ControleDeVeiculo controleDeVeiculos)
        {
            controleDeVeiculos.DataEntrada = DateTime.Now;
            await _controleDeVeiculosRepository.RegistrarEntrada(controleDeVeiculos);
        }
        public async Task RegistrarSaida(Saida saida)
        {
            saida.DataSaida = DateTime.Now;
            await _controleDeVeiculosRepository.RegistrarSaida(saida);
        }

        public async Task<IEnumerable<ControleDeVeiculo>> BuscarVeiculo(int id)
        {
            return await _controleDeVeiculosRepository.BuscarVeiculo(id);
        }
    }
}