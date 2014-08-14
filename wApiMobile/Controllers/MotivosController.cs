using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class MotivosController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        // GET api/diagnosticos
        public List<Motivo> Get()
        {
            List<Motivo> motivos = db.Database.SqlQuery<Motivo>("sp_GetFullList @tabla = {0}", "MotivosNoRealizacion")
                .ToList<Motivo>();

            return motivos;
        }

    }
}
