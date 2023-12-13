using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppFovimeFrontEnd.Models.ApiModels;
using System.Net;

namespace WebAppFovimeFrontEnd.Services
{
    public class RequestService:IRequestService
    {
        private string _URLBase {  get; set; }

        public RequestService() {            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _URLBase = builder.GetSection("ApiSettings:URLBase").Value;
        }

        public async Task<GeneralResponse> RequestPost(string urlPart,object body, string token = "") {                      

			var client = new HttpClient();            
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");            
            if(! string.IsNullOrEmpty(token)){
                client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);
            }
            var response = await client.PostAsync(_URLBase + urlPart, content);            
            var json_response= await response.Content.ReadAsStringAsync();

            GeneralResponse generalResponse = new GeneralResponse();
            generalResponse.body=json_response;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                generalResponse.ok = true;
                generalResponse.message="success";                
            }
            else
            {
                generalResponse.ok = false;
                generalResponse.message="error";                
                
            }
            return generalResponse;
        }

        public async Task<GeneralResponse> RequestPut(string urlPart, object body, string token)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");            
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);            
            var response = await client.PutAsync(_URLBase + urlPart, content);
            var json_response = await response.Content.ReadAsStringAsync();

            GeneralResponse generalResponse = new GeneralResponse();
            generalResponse.body=json_response;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                generalResponse.ok = true;
                generalResponse.message="success";                
            }
            else
            {
                generalResponse.ok = false;
                generalResponse.message="error";
            }

            return generalResponse;
        }        
        public async Task<GeneralResponse> RequestGet(string urlPart,string token)
        {
            var client = new HttpClient();            
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            var response = await client.GetAsync(_URLBase + urlPart);
            var json_response = await response.Content.ReadAsStringAsync();

            GeneralResponse generalResponse = new GeneralResponse();
            generalResponse.body=json_response;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                generalResponse.ok = true;
                generalResponse.message="success";                
            }
            else
            {
                generalResponse.ok = false;
                generalResponse.message="error";
            }
            return generalResponse;
        }

        public async Task<GeneralResponse> RequestDelete(string urlPart, string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync(_URLBase + urlPart);
            var json_response = await response.Content.ReadAsStringAsync();

            GeneralResponse generalResponse = new GeneralResponse();
            generalResponse.body=json_response;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                generalResponse.ok = true;
                generalResponse.message="success";                
            }
            else
            {
                generalResponse.ok = false;
                generalResponse.message="error";
            }
            return generalResponse;
        }
    }
}
