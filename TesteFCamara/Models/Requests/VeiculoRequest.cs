using System.ComponentModel.DataAnnotations;
using TesteFCamara.Models.Enums;

namespace TesteFCamara.Models.Requests
{
    public class VeiculoRequest : BaseRequest<Veiculo>
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public TipoVeiculo Tipo { get; set; }

        public override Veiculo ToModel()
            => new Veiculo()
            {
                ID = ID,
                Cor = Cor,
                Marca = Marca,
                Modelo = Modelo,
                Placa = Placa,
                Tipo = Tipo
            };
    }
}