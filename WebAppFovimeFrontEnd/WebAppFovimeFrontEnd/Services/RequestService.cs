using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFovimeFrontEnd.Services
{
    public class RequestService:IRequestService
    {
        private string _URLBase {  get; set; }

        public RequestService() {            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _URLBase = builder.GetSection("ApiSettings:URLBase").Value;
        }

        public async Task<string> RequestPost(string urlPart,object body, string token = "") {                      

			var client = new HttpClient();            
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");            
            if(! string.IsNullOrEmpty(token)){
                client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);
            }
            var response = await client.PostAsync(_URLBase + urlPart, content);
            var json_response= await response.Content.ReadAsStringAsync();            
            return json_response;
        }

        public async Task<string> RequestPut(string urlPart, object body, string token)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");            
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);            
            var response = await client.PutAsync(_URLBase + urlPart, content);
            var json_response = await response.Content.ReadAsStringAsync();
            return json_response;
        }        
        public async Task<string> RequestGet(string urlPart,string token)
        {
            var client = new HttpClient();            
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            var response = await client.GetAsync(_URLBase + urlPart);
            var json_response = await response.Content.ReadAsStringAsync();
            return json_response;
        }

        public async Task<string> RequestDelete(string urlPart, string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync(_URLBase + urlPart);
            var json_response = await response.Content.ReadAsStringAsync();
            return json_response;
        }
    }
}
