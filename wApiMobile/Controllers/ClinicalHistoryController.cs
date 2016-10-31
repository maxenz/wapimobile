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
        public List<HistoriaClinica> Get(int id)
        {
            string license = Helper.getValueFromQueryString("licencia");
            ShamanContext db = new ShamanContext(Helper.getConnectionStringBySerial(license));
            List<HistoriaClinica> hc = db.Database.SqlQuery<HistoriaClinica>("sp_GetHC @viajeId = {0}", id).ToList();
            return hc;
        }
     
    }
}
