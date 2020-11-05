using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFCamara.Models;
using Dapper;
using System.Linq;
using System.Transactions;
using TesteFCamara.Repositories.Interfaces;
using TesteFCamara.Data.Interfaces;
using TesteFCamara.Data.Queries;

namespace TesteFCamara.Repositories
{

    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EstabelecimentoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Estabelecimento>> Listar()
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<Estabelecimento>(EstabelecimentoQueries.Listar);
                }
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao listar estabelecimentos", e);
            }
        }

        public async Task Cadastrar(Estabelecimento estabelecimento)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var connection = _connectionFactory.CreateConnection())
                    {
                        await connection.ExecuteAsync(EstabelecimentoQueries.Cadastrar, estabelecimento);
                        scope.Complete();
                    }
                }
                catch (System.Exception e)
                {

                    scope.Dispose();
                    throw new Exception("Erro ao cadastrar estabelecimento", e);
                }
            }

        }

         public async Task Editar(Estabelecimento estabelecimento)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var connection = _connectionFactory.CreateConnection())
                    {
                        await connection.ExecuteAsync(EstabelecimentoQueries.Editar, estabelecimento);
                        scope.Complete();
                    }
                }
                catch (System.Exception e)
                {

                    scope.Dispose();
                    throw new Exception("Erro ao editar estabelecimento", e);
                }
            }

        }

         public async Task Remover(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var connection = _connectionFactory.CreateConnection())
                    {
                        await connection.ExecuteAsync(EstabelecimentoQueries.Remover, id);
                        scope.Complete();
                    }
                }
                catch (System.Exception e)
                {

                    scope.Dispose();
                    throw new Exception("Erro ao remover estabelecimento", e);
                }
            }

        }
    }
}