using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;

namespace TesteFCamara.Repositories.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        Task <IEnumerable<Estabelecimento>> Listar();
        Task Cadastrar(Estabelecimento estabelecimento);
        Task Editar(Estabelecimento estabelecimento);
        Task Remover(int id);
    }
    
}