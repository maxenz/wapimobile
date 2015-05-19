using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Models;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
    public class ReasonsController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        // GET api/diagnosticos
        public List<Motivo> Get()
        {
            string license = Helper.getValueFromQueryString("licencia");
            List<Motivo> motivos = db.Database.SqlQuery<Motivo>("sp_GetFullList @tabla = {0}", "MotivosNoRealizacion")
                .ToList<Motivo>();

            return motivos;
        }

    }
}
