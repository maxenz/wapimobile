using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class DiagnosticosController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        // GET api/diagnosticos
        public List<Diagnostico> Get()
        {
            List<Diagnostico> diagnosticos = db.Database.SqlQuery<Diagnostico>("sp_GetFullList @tabla = {0}", "Diagnosticos")
                .ToList<Diagnostico>();

            return diagnosticos;
        }

    }
}
