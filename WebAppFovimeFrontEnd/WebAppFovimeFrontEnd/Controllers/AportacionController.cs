using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFovimeFrontEnd.Helpers;
using WebAppFovimeFrontEnd.Models.ApiModels;
using WebAppFovimeFrontEnd.Models;
using WebAppFovimeFrontEnd.Services;
using Newtonsoft.Json;

namespace WebAppFovimeFrontEnd.Controllers
{
    [Authorize(Roles = "USER")]
    [Authorize]
	public class AportacionController : Controller
	{
		private readonly IRequestService _serviceApi;
		public AportacionController(IRequestService serviceApi)
		{
			_serviceApi = serviceApi;
		}
        
        [HttpGet]
		public IActionResult ViewAportaciones()
		{
			return View("Aportaciones");
		}
        
        [HttpGet]
		public async Task<JsonResult> GetAportaciones()
		{
            /*
            //Data dummy:
            List<Aportacion> aportaciones = new List<Aportacion>();
            aportaciones.Add(new Aportacion { n_i_anhio=2019, n_n_aporte01=200.52, n_n_aporte02=0, n_n_aporte03=1, n_n_aporte04=12, n_n_aporte05=1, n_n_aporte06=1, n_n_aporte07=1, n_n_aporte08=1, n_n_aporte09=1, n_n_aporte10=1, n_n_aporte11=1, n_n_aporte12=1, n_n_total=1001 });
            aportaciones.Add(new Aportacion { n_i_anhio=2020, n_n_aporte01=800.00, n_n_aporte02=0, n_n_aporte03=1, n_n_aporte04=1, n_n_aporte05=12.05, n_n_aporte06=1, n_n_aporte07=1, n_n_aporte08=1, n_n_aporte09=1, n_n_aporte10=1, n_n_aporte11=1, n_n_aporte12=1, n_n_total=5000 });
            aportaciones.Add(new Aportacion { n_i_anhio=2021, n_n_aporte01=403.11, n_n_aporte02=0, n_n_aporte03=1, n_n_aporte04=12, n_n_aporte05=1, n_n_aporte06=1, n_n_aporte07=1, n_n_aporte08=1, n_n_aporte09=1, n_n_aporte10=1, n_n_aporte11=1, n_n_aporte12=1, n_n_total=3001 });
            aportaciones.Add(new Aportacion { n_i_anhio=2022, n_n_aporte01=355.58, n_n_aporte02=2022, n_n_aporte03=1, n_n_aporte04=1, n_n_aporte05=12.05, n_n_aporte06=1, n_n_aporte07=1, n_n_aporte08=1, n_n_aporte09=1, n_n_aporte10=1, n_n_aporte11=1, n_n_aporte12=1, n_n_total=2583.10 });
            aportaciones.Add(new Aportacion { n_i_anhio=2023, n_n_aporte01=355.58, n_n_aporte02=2022, n_n_aporte03=1, n_n_aporte04=1, n_n_aporte05=12.05, n_n_aporte06=1, n_n_aporte07=1, n_n_aporte08=1, n_n_aporte09=1, n_n_aporte10=1, n_n_aporte11=1, n_n_aporte12=1, n_n_total=2583.10 });
			            
			*/
            string url = "aportations";
            var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));

			if (response.ok==true)
			{            
                return Json(new { data = JsonConvert.DeserializeObject<List<Aportacion>>(response.body) });
            }
			else
			{
                return Json(new { data = new List<Aportacion>() });
            }
		}
	}
}
