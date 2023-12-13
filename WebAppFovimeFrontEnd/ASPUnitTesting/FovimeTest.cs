using Newtonsoft.Json;
using WebAppFovimeFrontEnd.Controllers;
using WebAppFovimeFrontEnd.Services;

namespace ASPUnitTesting
{
    public class FovimeTest
    {
        private readonly AportacionController _aportacionController;
        private readonly CreditoController _creditoController;
        private readonly SimulatorController _simulacionController;
        private readonly UserController _userController;
        private readonly IRequestService _serviceRequest;

        public FovimeTest() {
            _serviceRequest=new RequestService();
            _aportacionController=new AportacionController(_serviceRequest);
            _creditoController=new CreditoController(_serviceRequest);
            _simulacionController=new SimulatorController(_serviceRequest);
            _userController=new UserController(_serviceRequest);
        }

        [Fact]
        public void GetValidateAccess_NotFound()
        {
            var result = _userController.ValidateAccess("111111111", "12345678");            
            Assert.NotNull(result);            
        }

        [Fact]
        public async Task  UpdateUserInfo_NotResult()
        {
            var result = await _userController.UpdatePersonalInfo("992555255", "miguel.taipe@gmail.com", "san juan de lurigancho");
            Assert.NotNull(result);
            // Verifica si el contenido es un JSON
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"ok\":true"), true);
        }

        [Fact]
        public void GetUserInfo_NotFound()
        {
            var result = _userController.ViewPersonalInfo();
            Assert.NotNull(result);            
        }        

        [Fact]
        public void GetAportaciones_NotFound()
        {
            var result=_aportacionController.GetAportaciones();
            Assert.NotNull(result);
        }        

        [Fact]
        public void GetCreditoById_NotFound()
        {
            var result = _creditoController.GetAllCreditsDetail("E1000005439");
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);            
        }

        [Fact]
        public void GetCreditos_NotFound()
        {
            var result = _creditoController.GetAllCredits();
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);
        }

        [Fact]
        public void ExecSimulacion_NotResult()
        {
            var result = _simulacionController.PerformSimulations(monto:25000, plazo:30);
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);
        }

        [Fact]
        public void SaveSolicitud_NotResult()
        {
            var result = _simulacionController.SaveSolicitud(monto: 25000, plazo: 30);
            Assert.NotNull(result);
            // Verifica si el contenido es un JSON
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"ok\":false"), true);
        }

        [Fact]
        public void GetSolicitudEstado_NotResult()
        {
            var result = _simulacionController.GetSolicitudEstado(idSimulacion:25);
            Assert.NotNull(result);
            // Verifica si el contenido es un JSON
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"ok\":true"), true);
        }

        [Fact]
        public void UpdateSolicitudEstado_NotResult()
        {
            var result = _simulacionController.UpdateSolicitudEstado(idEstado:2, "Any comments");
            Assert.NotNull(result);
            // Verifica si el contenido es un JSON
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"ok\":true"), true);
        }
        [Fact]
        public void GetSolicitudes_NotResult()
        {
            var result = _simulacionController.GetSolicitudesAll();
            Assert.NotNull(result);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);
        }
        [Fact]
        public void GetSolicitudesBySocio_NotResult()
        {
            var result = _simulacionController.GetSolicitudesBySocio();
            Assert.NotNull(result);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);
        }

        [Fact]
        public void GetSolicitudesDetalle_NotResult()
        {
            var result = _simulacionController.GetSolicitudDetail(idSimulacion:2);
            Assert.NotNull(result);
            // Verifica si recibe la data
            var json = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(json.Contains("\"data\":"), true);
        }        
    }
}