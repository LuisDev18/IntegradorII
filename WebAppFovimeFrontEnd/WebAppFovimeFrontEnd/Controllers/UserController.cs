using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebAppFovimeFrontEnd.Models;
using WebAppFovimeFrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using WebAppFovimeFrontEnd.Helpers;
using WebAppFovimeFrontEnd.Models.ApiModels;

namespace WebAppFovimeFrontEnd.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IRequestService _serviceApi;
        public UserController(IRequestService serviceApi)
        {
            _serviceApi = serviceApi;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> ValidateAccess(string user, string password)
        {
            UserLoginRequest userLogin = new UserLoginRequest();
            userLogin.usernameCIP= user;
            userLogin.password= password;

            string url = "user/login";
            string token = "";
            var response = await _serviceApi.RequestPost(url, userLogin, token);

            if (response.ok==true)
            {
                var resultado = JsonConvert.DeserializeObject<UserLoginResponse>(response.body);

                //traer los datos del usuario
                url = "user/profile";
                //var userinfo = await _serviceApi.RequestGet(url, token);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, resultado.body.usuario.usernameCIP));
                identity.AddClaim(new Claim(ClaimTypes.Name, resultado.body.usuario.usernameCIP));
                identity.AddClaim(new Claim(ClaimTypes.Role, resultado.body.usuario.role));
                identity.AddClaim(new Claim("cip", resultado.body.usuario.usernameCIP));
                identity.AddClaim(new Claim("token", resultado.body.token));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(24), IsPersistent = false });
                
                return Json(new { ok = true, usernameCIP = resultado.body.usuario.usernameCIP });
            }
            else {

                var resultado = JsonConvert.DeserializeObject<ErrorResponse>(response.body);
                return Json(new { ok = false, data = resultado });
            }
            
        }

        [Authorize(Roles = "USER")]
        public IActionResult ViewPersonalInfo()
        {
            //string url = "client/getClientInfo?cip="+UserLogin.GetIdUser(User);
            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<ClientInfoResponse>(response);

            ClientInfo client = new ClientInfo { c_t_cip="322278000", c_t_cliente="HURTADO LARA SATURNINO", c_t_grado="TECNICO DE PRIMERA", d_nacimiento=DateTime.Now, c_t_telefonoc="958545856", c_t_email="hurtado.s@gmail.com", c_t_direccion="La Perla-Callao" };
            ViewBag.ClientInfo=client;
            return View("DatosPersonales");
        }

        [Authorize(Roles = "USER")] 
        [HttpPost]
        public async Task<JsonResult> UpdatePersonalInfo(string phone, string email,string address)
        {            
            try {
                GeneralResponse response= new GeneralResponse { ok=true, message="Datos guardados correctamente" };
                return Json(response);
            }
            catch(Exception ex) {
                GeneralResponse response = new GeneralResponse { ok=false, message="No se pudieron guardar los datos del socio" };
                return Json(response);
            }
        }

        [HttpGet]        
        public async Task<IActionResult> CloseSession()
        {
            await HttpContext.SignOutAsync();
            return View("Login");
        }

		[AllowAnonymous]        
        public IActionResult RedirectUser()
        {
            if (User.Identity!=null && User.Identity.IsAuthenticated)
            {
                if (UserLogin.GetRolUser(User) == "ADMIN")
                {
                    return Redirect("~/Simulator/ViewCreditRequests");
                }
                else
                {
                    return Redirect("~/Home/Index");
                }                
            }
            else {
                return View("Login");
            }
            
        }
    }
}
