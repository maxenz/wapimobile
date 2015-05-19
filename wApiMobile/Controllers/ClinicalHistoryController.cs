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
    public class ClinicalHistoryController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        public List<HistoriaClinica> Get(int id)
        {
            string license = Helper.getValueFromQueryString("licencia");
            List<HistoriaClinica> hc = db.Database.SqlQuery<HistoriaClinica>("sp_GetHC @viajeId = {0}", id).ToList<HistoriaClinica>();
            return hc;
        }
     
    }
}
