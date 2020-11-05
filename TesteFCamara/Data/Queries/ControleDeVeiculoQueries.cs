namespace TesteFCamara.Data.Queries
{
    public class ControleDeVeiculoQueries
    {
        public static string RegistrarEntrada
        => @"INSERT INTO ControleDeVeiculos(Veiculo, Estabelecimento, DataEntrada)
             VALUES
             (@Veiculo, @Estabelecimento, @DataEntrada)";

        public static string RegistrarSaida
        => @"UPDATE ControleDeVeiculos SET DataSaida = @DataSaida
             WHERE ID = @IDControle";

        public static string BuscarVeiculo
         => @"SELECT*FROM ControleDeVeiculos WHERE ID = @id";
    }
}