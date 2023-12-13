namespace WebAppFovimeFrontEnd.Models.ApiModels
{
    public class ErrorResponse
    {
        public DateTime timestamp {  get; set; }
        public string message { get; set; }
        public string path { get; set; }
        public string errorCode { get; set; }

    }
}
