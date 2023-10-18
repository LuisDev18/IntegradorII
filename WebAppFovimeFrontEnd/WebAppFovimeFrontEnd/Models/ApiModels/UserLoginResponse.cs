namespace WebAppFovimeFrontEnd.Models.ApiModels
{
    public class UserLoginResponse
    {        
        public bool ok { get; set; }
        public string? message { get; set; }
        public UserInfoBody? body { get; set; }
    }
}
