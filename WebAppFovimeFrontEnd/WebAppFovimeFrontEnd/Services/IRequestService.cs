using WebAppFovimeFrontEnd.Models.ApiModels;

namespace WebAppFovimeFrontEnd.Services
{
    public interface IRequestService
    {
        Task<GeneralResponse> RequestPost(string urlPart, object body, string token = "");
        Task<GeneralResponse> RequestPut(string urlPart, object body, string token);
        Task<GeneralResponse> RequestGet(string urlPart, string token);
        Task<GeneralResponse> RequestDelete(string urlPart, string token);
    }
}
