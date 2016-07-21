using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class ServicioDetalle 
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
        public string Institucion { get; set; }
        public string ColorHexa { get; set; }
        public byte HabSalida { get; set; }
        public byte HabLlegada { get; set; }
        public byte HabFinal { get; set; }
        public byte HabCancelacion { get; set; }
        public string FecIncidente { get; set; }
        public string NroAfiliado { get; set; }
        public string Aviso { get; set; }
        public string Partido { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public string Referencia { get; set; }
        public string Sintomas { get; set; }
        public string Paciente { get; set; }
        public string PlanId { get; set; }
        public int CoPago { get; set; }
        public string Observaciones { get; set; }
        public string Telefono { get; set; }
        public int ClasificacionId { get; set; }
        public byte FlgRename { get; set; }
        public byte FlgDerivacion { get; set; }
        public string DerLocalidad { get; set; }
        public string DerPartido { get; set; }
        public string DerInstitucion { get; set; }
        public string DerDomicilio { get; set; }
        public string DerEntreCalle1 { get; set; }
        public string DerEntreCalle2 { get; set; }
        public string DerReferencia { get; set; }
        public string DerLatitud { get; set; }
        public string DerLongitud { get; set; }
        public string Diagnostico { get; set; }
        public string SintomasItems { get; set; }

    }
}