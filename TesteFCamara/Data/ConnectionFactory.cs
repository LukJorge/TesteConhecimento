using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TesteFCamara.Data.Interfaces;

namespace TesteFCamara.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("TesteFCamara"));
        }
    }
}