namespace WebAppFovimeFrontEnd.Models
{
    public class Solicitud
    {
        public int idSimulacion { get; set; }
        public string c_t_cip { get; set; }
        public string socio { get; set; }
        public string grado { get; set; }
        public string d_nacimiento { get; set; }
        public string d_documento { get; set; }
        public int n_i_plazo { get; set; }
        public double n_n_cuota { get; set; }
        public double n_n_monto { get; set; }
        public int idEstado { get; set; }

    }
}
