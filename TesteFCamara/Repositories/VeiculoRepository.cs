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
	public class VeiculoRepository : IVeiculoRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public VeiculoRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<IEnumerable<Veiculo>> Listar()
		{
			try
			{
				using (var connection = _connectionFactory.CreateConnection())
				{
					return await connection.QueryAsync<Veiculo>(VeiculoQueries.Listar);
				}
			}
			catch (System.Exception e)
			{
				throw new Exception("Erro ao listar veiculo", e);
			}
		}

		public async Task Cadastrar(Veiculo veiculo)
		{
			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					using (var connection = _connectionFactory.CreateConnection())
					{
						await connection.ExecuteAsync(VeiculoQueries.Cadastrar,
						new
						{
							veiculo.Marca,
							veiculo.Modelo,
							veiculo.Cor,
							veiculo.Placa,
							Tipo = veiculo.Tipo.ToString()
						});
						scope.Complete();
					}
				}
				catch (System.Exception e)
				{

					scope.Dispose();
					throw new Exception("Erro ao cadastrar veiculo", e);
				}
			}

		}

		public async Task Editar(Veiculo veiculo)
		{
			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					using (var connection = _connectionFactory.CreateConnection())
					{
						await connection.ExecuteAsync(VeiculoQueries.Editar, veiculo);
						scope.Complete();
					}
				}
				catch (System.Exception e)
				{

					scope.Dispose();
					throw new Exception("Erro ao editar veiculo", e);
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
						await connection.ExecuteAsync(VeiculoQueries.Remover, id);
						scope.Complete();
					}
				}
				catch (System.Exception e)
				{

					scope.Dispose();
					throw new Exception("Erro ao remover veiculo", e);
				}
			}

		}
	}
}