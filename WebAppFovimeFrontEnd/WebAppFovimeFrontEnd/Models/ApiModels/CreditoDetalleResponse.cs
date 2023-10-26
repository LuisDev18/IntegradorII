namespace WebAppFovimeFrontEnd.Models.ApiModels
{
	public class CreditoDetalleResponse
	{		
		public string? status { get; set; }
		public string? message { get; set; }
		public List<CreditoDetalle> data { get; set; }		
	}
}
