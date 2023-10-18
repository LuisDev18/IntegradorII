namespace WebAppFovimeFrontEnd.Models.ApiModels
{
	public class CreditosResponse
	{
		public string? status { get; set; }
		public string? message { get; set; }
		public List<Credito> data { get; set; }
	}
}
