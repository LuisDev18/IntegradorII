using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebAppFovimeFrontEnd.Services;
using WebAppFovimeFrontEnd.Helpers;
using Microsoft.AspNetCore.Authorization;
using WebAppFovimeFrontEnd.Models;
using WebAppFovimeFrontEnd.Models.ApiModels;
using System.Collections.Generic;

namespace WebAppFovimeFrontEnd.Controllers
{
    [Authorize]
    public class SimulatorController : Controller
    {
        private readonly IRequestService _serviceApi;
        public SimulatorController(IRequestService serviceApi)
        {
            _serviceApi = serviceApi;
        }

        [Authorize(Roles = "USER")]
        [HttpGet]
        public IActionResult ViewSimulator()
        {
            ClientInfo client = new ClientInfo { c_t_cip="322278000", c_t_cliente="HURTADO LARA SATURNINO", c_t_grado="TECNICO DE PRIMERA", d_nacimiento=DateTime.Now, c_t_telefonoc="958545856", c_t_email="hurtado.s@gmail.com", c_t_direccion="La Perla-Callao" };
            ViewBag.ClientInfo=client;
            return View("Simulador");
        }


        [Authorize(Roles = "USER")]
        [HttpPost]
        public JsonResult PerformSimulations(double monto, int plazo)
        {
            string url = "simulator/procesarSimulacion";

            //Data dummy:
            List<SimulacionDetalle> simulacionDetalle = new List<SimulacionDetalle>();
            simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=1, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=8000, n_n_capital=250, n_n_interes=0, n_n_seguro=15.09, n_n_comision=250, n_n_total=11000 });
            simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=2, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=9000, n_n_capital=185, n_n_interes=545, n_n_seguro=15.30, n_n_comision=300, n_n_total=12000 });
            simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=3, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=10000, n_n_capital=250, n_n_interes=777, n_n_seguro=15.09, n_n_comision=250, n_n_total=13000 });
            simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=4, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=11000, n_n_capital=250, n_n_interes=777, n_n_seguro=15.09, n_n_comision=325, n_n_total=14000 });

            return Json(new { data = simulacionDetalle });

        }

        [Authorize(Roles = "USER")]
        [HttpPost]
        public JsonResult SaveSolicitud(double monto, int plazo)
        {
            string url = "simulator/saveSolicitud";
                        
            try
            {
                GeneralResponse response = new GeneralResponse { ok=true, message="Solicitud enviada correctamente" };
                return Json(response);
            }
            catch (Exception ex)
            {
                GeneralResponse response = new GeneralResponse { ok=false, message="No se pudo registrar la solicitud, intentelo de nuevo mas tarde" };
                return Json(response);
            }
        }
            
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public JsonResult GetSolicitudEstado(int idSimulacion)
        {
            string url = "solicitud/getSolicitudEstado?idSimulacion=" + idSimulacion.ToString();
            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            if (idSimulacion==1) return Json(new { idEstado=1,comentarios="", message = "error", ok = true });
            else if (idSimulacion==2) return Json(new { idEstado = 2, comentarios = "Estamos evaluando su solicitud", message = "error", ok = true });
            else return Json(new { idEstado = 3, comentarios = "El monto solicitiado es muy elevado",message="error",ok=true });

        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public JsonResult UpdateSolicitudEstado(int idEstado, string comentarios)
        {
            string url = "simulator/updateEstadoSolicitud";

            try
            {
                GeneralResponse response = new GeneralResponse { ok=true, message="Se actualizó el estado de la solicitud correctamente" };
                return Json(response);
            }
            catch (Exception ex)
            {
                GeneralResponse response = new GeneralResponse { ok=false, message="No se pudo actualizar los datos, intentelo de nuevo mas tarde" };
                return Json(response);
            }
        }

        [HttpGet]
        public IActionResult ViewCreditRequests()
        {
            if (UserLogin.GetRolUser(User)=="ADMIN")
            {
                return View("SolicitudesAdmin");
            }
            else
            {
                return View("SolicitudesUser");
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public JsonResult GetSolicitudesAll()
        {
            string url = "solicitud/getSolicitudesAll";
            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            //Data dummy:
            List<Solicitud> solicitudes = new List<Solicitud>();
            solicitudes.Add(new Solicitud { idSimulacion=1, c_t_cip="322278000", socio="HURTADO LARA SATURNINO", grado="TECNICO TERCERA", d_nacimiento=DateTime.Now.ToString("dd-MM-yyyy"), d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_i_plazo=180, n_n_cuota=240.5, n_n_monto=2520.22, idEstado=1,comentarios="Sin comentarios" });
            solicitudes.Add(new Solicitud { idSimulacion=2, c_t_cip="559665556", socio="JUAN RAMOS", grado="TECNICO SEGUNDA", d_nacimiento=DateTime.Now.ToString("dd-MM-yyyy"), d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_i_plazo=300, n_n_cuota=240.5, n_n_monto=12225, idEstado=2, comentarios="Sin comentarios" });
            solicitudes.Add(new Solicitud { idSimulacion=3, c_t_cip="222255663", socio="VILMA PEREZ", grado="CAPITAN", d_nacimiento=DateTime.Now.ToString("dd-MM-yyyy"), d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_i_plazo=200, n_n_cuota=240.5, n_n_monto=8000, idEstado=3, comentarios="Sin comentarios" });

            return Json(new { data = solicitudes });
        }

        [Authorize(Roles = "USER")]
        [HttpGet]
        public JsonResult GetSolicitudesBySocio()
        {
            //string url = "solicitud/getSolicitudesBySocio?cip=" + UserLogin.GetIdUser(User);
            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            //Data dummy:
            List<Solicitud> solicitudes = new List<Solicitud>();
            solicitudes.Add(new Solicitud { idSimulacion=1, n_i_plazo=180, d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_cuota=240.5, n_n_monto=2520.22, idEstado=1, comentarios="Sin comentarios" });
            solicitudes.Add(new Solicitud { idSimulacion=10, n_i_plazo=200, d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_cuota=2522, n_n_monto=5000, idEstado=2, comentarios="Sin comentarios" });
            solicitudes.Add(new Solicitud { idSimulacion=20, n_i_plazo=300, d_documento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_cuota=1000, n_n_monto=7000, idEstado=3, comentarios="Sin comentarios" });

            return Json(new { data = solicitudes });
        }

        [HttpGet]
        public JsonResult GetSolicitudDetail(int idSimulacion)
        {
            string url = "solicitud/getSolicitudDetalleBy?idSimulacion="+idSimulacion;

            //var response = await _serviceApi.RequestGet(url, UserLogin.GetValueUser(User, "token"));
            //var resultado = JsonConvert.DeserializeObject<GroupsResponse>(response);

            //Data dummy:
            List<SimulacionDetalle> simulacionDetalle = new List<SimulacionDetalle>();
            if (idSimulacion==1)
            {
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=1, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=2500, n_n_capital=250, n_n_interes=0, n_n_seguro=15.09, n_n_comision=250, n_n_total=1000 });
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=2, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=3000, n_n_capital=185, n_n_interes=125, n_n_seguro=15.30, n_n_comision=300, n_n_total=2000 });

            }
            else if (idSimulacion==10)
            {
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=1, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=5000, n_n_capital=250, n_n_interes=0, n_n_seguro=15.09, n_n_comision=250, n_n_total=7000 });
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=2, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=6000, n_n_capital=185, n_n_interes=263, n_n_seguro=15.30, n_n_comision=300, n_n_total=8000 });
            }
            else
            {
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=1, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=8000, n_n_capital=250, n_n_interes=0, n_n_seguro=15.09, n_n_comision=250, n_n_total=11000 });
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=2, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=9000, n_n_capital=185, n_n_interes=545, n_n_seguro=15.30, n_n_comision=300, n_n_total=12000 });
                simulacionDetalle.Add(new SimulacionDetalle { n_i_cuota=3, d_vencimiento=DateTime.Now.ToString("dd-MM-yyyy"), n_n_saldoini=10000, n_n_capital=250, n_n_interes=777, n_n_seguro=15.09, n_n_comision=250, n_n_total=13000 });
            }

            return Json(new { data = simulacionDetalle });
        }
    }
}
