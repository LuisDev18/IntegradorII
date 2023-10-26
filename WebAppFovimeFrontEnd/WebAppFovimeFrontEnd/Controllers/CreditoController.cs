using Microsoft.AspNetCore.Mvc;
using WebAppFovimeFrontEnd.Helpers;
using WebAppFovimeFrontEnd.Models.ApiModels;
using WebAppFovimeFrontEnd.Models;
using WebAppFovimeFrontEnd.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebAppFovimeFrontEnd.Controllers
{
    [Authorize(Roles = "USER")]
    [Authorize]
    public class CreditoController : Controller
    {
        private readonly IRequestService _serviceApi;
        public CreditoController(IRequestService serviceApi)
        {
            _serviceApi = serviceApi;
        }

        [HttpGet]
        public IActionResult ViewCreditos()
        {
            return View("Creditos");
        }

        [HttpGet]
        public JsonResult GetAllCredits()
        {
            string url = "credito/getCreditosBy?cip="+UserLogin.GetIdUser(User);            
            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            //Data dummy:
            List<Credito> creditos = new List<Credito>();
            creditos.Add(new Credito { c_c_expediente="E1000005439", n_i_cronograma=1, d_liquidacion=DateTime.Now.ToString("dd-MM-yyyy"),c_t_moneda="USD", n_N_total=2500.25, c_t_producto="ESTACIONAMIENTO" });
            creditos.Add(new Credito { c_c_expediente="E1000005500", n_i_cronograma=2, d_liquidacion=DateTime.Now.ToString("dd-MM-yyyy"), c_t_moneda="USD", n_N_total=5000, c_t_producto="ESTACIONAMIENTO" });
            creditos.Add(new Credito { c_c_expediente="E1000006001", n_i_cronograma=3, d_liquidacion=DateTime.Now.ToString("dd-MM-yyyy"), c_t_moneda="USD", n_N_total=4268, c_t_producto="DEPARTAMENTO" });

            /*
            string showEditStatus="0";
            if (UserLogin.GetRolUser(User)=="ADMIN") {
                showEditStatus = "1";
            }
            var resultado2= resultado.data.Select(x => new { x.idCredito,x.montoTotal,x.fecha, x.idEstatus,statusEdit = x.idCredito.ToString()+"-"+showEditStatus }).ToList();
            */

            return Json(new { data = creditos });
        }

        [HttpGet]
        public JsonResult GetAllCreditsDetail(string expediente)
        {
            string url = "credito/getCreditosDetalleBy?c_c_expediente="+expediente;

            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            //Data dummy:
            List<CreditoDetalle> creditosDetalle = new List<CreditoDetalle>();
            if (expediente=="E1000005439")
            {
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=1, c_t_concepto="INIC", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2500, n_n_capital=250, n_n_intprg=0, n_n_cuota=15.09, n_n_cuotat=250, n_n_segprg=0, n_n_comprg=0, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=2, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="VIGENTE" });
            }
            else
            {
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=1, c_t_concepto="INIC", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2500, n_n_capital=250, n_n_intprg=0, n_n_cuota=15.09, n_n_cuotat=250, n_n_segprg=0, n_n_comprg=0, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=2, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=3, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=4, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=5, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="CANCELADO" });
                creditosDetalle.Add(new CreditoDetalle { n_i_cuota=6, c_t_concepto="REGU", d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2250, n_n_capital=3.03, n_n_intprg=7.37, n_n_cuota=15.09, n_n_cuotat=15.09, n_n_segprg=1.46, n_n_comprg=3.23, n_n_total=2500, c_t_estado1="CANC", c_t_estado="VIGENTE" });
            }                        

            return Json(new { data = creditosDetalle });
        }
    }
}
