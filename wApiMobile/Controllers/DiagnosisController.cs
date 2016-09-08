using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using wApiMobile.Models;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
    public class DiagnosisController : ApiController
    {
        private ShamanContext db = new ShamanContext();
        // GET api/diagnosticos
        public List<Diagnostico> Get()
        {
            string license = Helper.getValueFromQueryString("licencia");
            List<Diagnostico> diagnosticos = db.Database.SqlQuery<Diagnostico>("sp_GetFullList @tabla = {0}", "Diagnosticos")
                .ToList<Diagnostico>();

            return diagnosticos;
        }

    }
}
