using System.Data.SqlClient;

namespace TesteFCamara.Data.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}