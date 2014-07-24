using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class Servicio
    {
        public String IdServicio { get; set; }
        public String NroServicio { get; set; }
        public int Grado { get; set; }
        public String Sexo { get; set; }
        public int Edad { get; set; }
        public String Domicilio { get; set; }
        public String Cliente { get; set; }
        public String Horario { get; set; }

        public Servicio(string id, string nro, int gdo, string sexo, int edad, string dom, string cli, string hor)
        {
            IdServicio = id;
            NroServicio = nro;
            Grado = gdo;
            Sexo = sexo;
            Edad = edad;
            Domicilio = dom;
            Cliente = cli;
            Horario = hor;
        }
    }
}