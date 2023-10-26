namespace WebAppFovimeFrontEnd.Models.ApiModels
{
	public class AportacionesResponse
	{
		public bool ok { get; set; }
		public string? message { get; set; }
		public List<Aportacion> body { get; set; }
	}
}
