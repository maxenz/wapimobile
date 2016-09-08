using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{

    public class Servicio
    {
        [Key]
        public long IdServicio { get; set; }
        public string NroServicio { get; set; }
        public string Grado { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Domicilio { get; set; }
        public string Cliente { get; set; }
        public string Horario { get; set; }
        public string Localidad { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string ColorHexa { get; set; }
        public int CurrentViaje { get; set; }
        public DateTime HorLlamada { get; set; }


    }
}