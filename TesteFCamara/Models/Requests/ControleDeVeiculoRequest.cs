using System.ComponentModel.DataAnnotations;

namespace TesteFCamara.Models.Requests
{
	public class ControleDeVeiculoRequest : BaseRequest<ControleDeVeiculo>
	{
		[Key]
		public int ID { get; set; }
		[Required(ErrorMessage = "Este campo é obrigatório")]
		public Veiculo Veiculo { get; set; }
		[Required(ErrorMessage = "Este campo é obrigatório")]
		public Estabelecimento Estabelecimento { get; set; }

		public override ControleDeVeiculo ToModel()
		=> new ControleDeVeiculo()
		{
			ID = ID,
			Veiculo = Veiculo,
			Estabelecimento = Estabelecimento
		};
	}
}
