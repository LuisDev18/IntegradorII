namespace WebAppFovimeFrontEnd.Models
{
    public class GroupsResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<UserInfoBody> data { get; set; }        
    }
}
