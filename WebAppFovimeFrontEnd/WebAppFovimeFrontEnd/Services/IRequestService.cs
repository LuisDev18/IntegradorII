namespace WebAppFovimeFrontEnd.Services
{
    public interface IRequestService
    {
        Task<string> RequestPost(string urlPart, object body, string token = "");
        Task<string> RequestPut(string urlPart, object body, string token);
        Task<string> RequestGet(string urlPart, string token);
        Task<string> RequestDelete(string urlPart, string token);
    }
}
