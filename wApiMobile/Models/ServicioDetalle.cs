using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class ServicioDetalle
    {
        public Int64 IdServicio { get; set; }
        public String NroServicio { get; set; }
        public String Grado { get; set; }
        public String Sexo { get; set; }
        public Int32 Edad { get; set; }
        public String Domicilio { get; set; }
        public String Cliente { get; set; }
        public String Localidad { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }

        public String FecIncidente { get; set; }
        public String NroAfiliado { get; set; }
        public String Aviso { get; set; }
        public String Partido { get; set; }
        public String EntreCalle1 { get; set; }
        public String EntreCalle2 { get; set; }
        public String Referencia { get; set; }
        public String Sintomas { get; set; }
        public String Paciente { get; set; }
        public String PlanId { get; set; }
        public int CoPago { get; set; }
        public String Observaciones { get; set; }
    }
}