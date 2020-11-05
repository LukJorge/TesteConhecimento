namespace TesteFCamara.Client.Model
{
    public class Estabelecimento
    {
        public int ID {get; set;}

        public string Nome {get; set;}

        public string CNPJ {get; set;}

        public string Endereco {get; set;}

        public string Telefone {get; set;}
        
        public int QtVagasMotos {get; set;}
        
        public int QtVagasCarros {get; set;}
    }
}