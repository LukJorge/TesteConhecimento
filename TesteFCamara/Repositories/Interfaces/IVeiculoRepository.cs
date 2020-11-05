using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> Listar();
        Task Cadastrar(Veiculo veiculo);
        Task Editar(Veiculo veiculo);
        Task Remover(int id);
    }
}