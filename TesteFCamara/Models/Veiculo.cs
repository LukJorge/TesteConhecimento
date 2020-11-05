using TesteFCamara.Models.Enums;

namespace TesteFCamara.Models
{

    public class Veiculo
    {
        public int ID {get; set;}
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public string Cor {get; set;}
        public string Placa {get; set;}
        public TipoVeiculo Tipo {get; set;}
    }
}