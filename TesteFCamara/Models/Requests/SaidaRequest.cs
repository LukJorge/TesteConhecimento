namespace TesteFCamara.Models.Requests
{
	public class SaidaRequest : BaseRequest<Saida>
	{
		public int ID { get; set; }

		public override Saida ToModel()
		=> new Saida() { IDControle = ID };
	}
}
