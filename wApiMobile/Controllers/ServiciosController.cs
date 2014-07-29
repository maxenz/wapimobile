using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class ServiciosController : ApiController
    {
        private ShamanContext db = new ShamanContext();

        private string qryGetServicios = " SELECT vij.ID IdServicio, gdo.AbreviaturaId AS Grado, inc.NroIncidente NroServicio, " +
            "cli.AbreviaturaId AS Cliente,inc.Sexo, CONVERT(INT,inc.Edad) Edad,CONVERT(VARCHAR(5),vij.horLlamada,108) Horario, dom.Domicilio, " +
            "loc.AbreviaturaId AS Localidad,CONVERT(VARCHAR(15), dom.dmLatitud) AS Latitud,CONVERT(VARCHAR(15),dom.dmLongitud) AS Longitud " + 
            "FROM IncidentesViajes vij " +
            "INNER JOIN Moviles mov ON (vij.MovilId = mov.ID OR vij.MovilPreasignadoId = mov.ID) " +
            "INNER JOIN IncidentesDomicilios dom ON vij.IncidenteDomicilioId = dom.ID " +
            "INNER JOIN Incidentes inc ON dom.IncidenteId = inc.ID " +
            "INNER JOIN GradosOperativos gdo ON inc.GradoOperativoId = gdo.ID " +
            "INNER JOIN Clientes cli ON inc.ClienteId = cli.ID " +
            "INNER JOIN Localidades loc ON dom.LocalidadId = loc.ID " +
            "WHERE vij.flgStatus = 0 ";

        private string qryGetDetalleServicio = "select vij.ID IdServicio," +
            "LEFT(CONVERT(VARCHAR, inc.FecIncidente, 103), 10) FecIncidente, inc.NroIncidente NroServicio," +
            "cli.AbreviaturaId AS Cliente, inc.NroAfiliado, inc.Aviso,loc.Descripcion AS Localidad, par.Descripcion AS Partido," +
            "dom.Domicilio, dom.dmEntreCalle1 EntreCalle1, dom.dmEntreCalle2 EntreCalle2,dom.dmReferencia Referencia," +
            "CONVERT(VARCHAR(15),dom.dmLatitud) Latitud," +
            "CONVERT(VARCHAR(15),dom.dmLongitud) Longitud, inc.Sexo,CONVERT(INT,inc.Edad) Edad, inc.Sintomas," +
            "gdo.AbreviaturaId AS Grado,inc.Paciente, inc.PlanId, CONVERT(INT,inc.CoPago) CoPago, inc.Observaciones " +
            "from IncidentesViajes vij " +
            "INNER JOIN IncidentesDomicilios dom ON vij.IncidenteDomicilioId = dom.ID " +
            "INNER JOIN Incidentes inc ON dom.IncidenteId = inc.ID " +
            "INNER JOIN Clientes cli ON inc.ClienteId = cli.ID " +
            "INNER JOIN GradosOperativos gdo ON inc.GradoOperativoId = gdo.ID " +
            "LEFT JOIN Localidades loc ON dom.LocalidadId = loc.ID " +
            "LEFT JOIN Localidades par ON loc.PartidoId = par.ID " +
            "WHERE vij.ID = ";

        // GET api/<controller>
        public List<Servicio> Get()
        {
            var query = HttpContext.Current.Request.QueryString;
            string idMovil = query.GetValues("idMovil")[0];

            qryGetServicios += " AND mov.Movil = '" + idMovil + "'";

            List<Servicio> servicios = db.Database.SqlQuery<Servicio>(qryGetServicios).ToList();
            return servicios;
           
        }

        // GET api/<controller>/5
        public ServicioDetalle Get(int id)
        {
            qryGetDetalleServicio += id;
            ServicioDetalle svDetalle = db.Database.SqlQuery<ServicioDetalle>(qryGetDetalleServicio).FirstOrDefault();
            return svDetalle;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}