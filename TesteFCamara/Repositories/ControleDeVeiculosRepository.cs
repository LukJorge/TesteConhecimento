using System.Transactions;
using System.Threading.Tasks;
using TesteFCamara.Repositories.Interfaces;
using TesteFCamara.Data.Interfaces;
using TesteFCamara.Models;
using System;
using TesteFCamara.Data.Queries;
using Dapper;
using System.Collections.Generic;

namespace TesteFCamara.Repositories
{
	public class ControleDeVeiculosRepository : IControleDeVeiculosRepository
	{
		private readonly IConnectionFactory _connectionFactory;
		public ControleDeVeiculosRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}
		public async Task RegistrarEntrada(ControleDeVeiculo controleDeVeiculos)
		{
			var parametros = new
			{
				Veiculo = controleDeVeiculos.Veiculo.ID,
				Estabelecimento = controleDeVeiculos.Estabelecimento.ID,
				controleDeVeiculos.DataEntrada
			};

			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					using (var connection = _connectionFactory.CreateConnection())
					{
						await connection.ExecuteAsync(ControleDeVeiculoQueries.RegistrarEntrada, parametros);
						scope.Complete();
					}
				}
				catch (Exception e)
				{
					scope.Dispose();
					throw new Exception("Erro ao registrar evento", e);
				}
			}
		}

		public async Task RegistrarSaida(Saida saida)
		{
			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					using (var connection = _connectionFactory.CreateConnection())
					{
						await connection.ExecuteAsync(ControleDeVeiculoQueries.RegistrarSaida, saida);
						scope.Complete();
					}
				}
				catch (Exception e)
				{
					scope.Dispose();
					throw new Exception("Erro ao registrar evento", e);
				}
			}
		}

		public async Task<IEnumerable<ControleDeVeiculo>> BuscarVeiculo(int id)
		{
			try
			{
				using (var connection = _connectionFactory.CreateConnection())
				{
					return await connection.QueryAsync<ControleDeVeiculo>(ControleDeVeiculoQueries.BuscarVeiculo, id);
				}
			}
			catch (System.Exception e)
			{
				throw new Exception("Erro ao buscar veiculo", e);
			}
		}
	}
}