using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class HistoriaClinica
    {
        public Int64 ID { get; set; }
        public string FecIncidente { get; set; }
        public string NroServicio { get; set; }
        public string ColorHexa { get; set; }
        public string Grado { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Movil { get; set; }
        public string Paciente { get; set; }
    }
}