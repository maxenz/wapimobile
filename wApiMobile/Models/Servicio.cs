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
        public Int64 IdServicio { get; set; }
        public String NroServicio { get; set; }
        public String Grado { get; set; }
        public String Sexo { get; set; }
        public Int32 Edad { get; set; }
        public String Domicilio { get; set; }
        public String Cliente { get; set; }
        public String Horario { get; set; }
        public String Localidad { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String ColorHexa { get; set; }
        public Int32 CurrentViaje { get; set; }

    }
}