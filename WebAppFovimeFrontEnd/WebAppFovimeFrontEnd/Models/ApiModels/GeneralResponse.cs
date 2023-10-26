namespace WebAppFovimeFrontEnd.Models.ApiModels
{
    public class GeneralResponse
    {
        public bool ok { get; set; }
        public string? message { get; set; }
        public object? body { get; set; }
    }
}
