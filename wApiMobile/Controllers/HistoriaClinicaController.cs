using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class HistoriaClinicaController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        public List<HistoriaClinica> Get(int id)
        {
            List<HistoriaClinica> hc = db.Database.SqlQuery<HistoriaClinica>("sp_GetHC @viajeId = {0}", id).ToList<HistoriaClinica>();
            return hc;
        }
     
    }
}
