using TesteFCamara.Models;

namespace TesteFCamara.Data.Queries
{
    public class EstabelecimentoQueries
    {
        public static string Cadastrar => @"INSERT INTO Estabelecimento(nome, CNPJ, Endereco,Telefone, QtVagasCarros, QtVagasMotos)
                                            values (@Nome,@CNPJ,@Endereco,@Telefone,@QtVagasMotos,@QtVagasCarros)";

        public static string Listar => @"SELECT*FROM Estabelecimento";

        public static string Editar =>
         @"UPDATE Estabelecimento
        SET NOME = @nome, CNPJ = @cnpj, ENDERECO = @endereco, TELEFONE = @telefone, QTVAGASCARROS = @qtVagasCarros, QTVAGASMOTOS = @qtVagasMotos
        WHERE ID = @id";
        
        public static string Remover => @"DELETE FROM Estabelecimento WHERE ID = @id";
    }
}