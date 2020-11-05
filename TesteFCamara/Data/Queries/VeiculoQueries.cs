namespace TesteFCamara.Data.Queries
{
    public class VeiculoQueries
    {
        public static string Cadastrar => @"INSERT INTO Veiculo(marca, modelo, cor,placa, tipo)
                                            values (@Marca,@Modelo,@Cor,@Placa,@Tipo)";

        public static string Listar => @"SELECT*FROM Veiculo";

        public static string Editar =>
         @"UPDATE Veiculo
        SET MARCA = @marca, MODELO = @modelo, COR = @cor, PLACA = @placa, TIPO = @tipo
        WHERE ID = @id";
        
        public static string Remover => @"DELETE FROM Veiculo WHERE ID = @id";
        
    }
}