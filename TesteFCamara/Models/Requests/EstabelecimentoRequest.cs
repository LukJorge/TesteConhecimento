using System.ComponentModel.DataAnnotations;

namespace TesteFCamara.Models.Requests
{
    public class EstabelecimentoRequest : BaseRequest<Estabelecimento>
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int QtVagasMotos { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int QtVagasCarros { get; set; }

        public override Estabelecimento ToModel()
        => new Estabelecimento
        {
            ID = ID,
            Nome = Nome, 
            CNPJ = CNPJ, 
            Endereco = Endereco, 
            Telefone = Telefone, 
            QtVagasCarros = QtVagasCarros, 
            QtVagasMotos = QtVagasMotos
        };
    }
}