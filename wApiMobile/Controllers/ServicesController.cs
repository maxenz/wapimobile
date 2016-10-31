using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using wApiMobile.Models;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
    public class ServicesController : ApiController
    {

        // GET api/<controller>
        public List<Servicio> Get()
        {
            string license = Helper.getValueFromQueryString("licencia");
            string idMovil = Helper.getValueFromQueryString("idMovil");
            ShamanContext db = new ShamanContext(Helper.getConnectionStringBySerial(license));
            List<Servicio> servicios = db.Database.SqlQuery<Servicio>("sp_GetViajesMovil @movil = {0}", idMovil).ToList();
            return servicios;
           
        }

        // GET api/<controller>/5
        public ServicioDetalle Get(int id)
        {
            string license = Helper.getValueFromQueryString("licencia");
            string idMovil = Helper.getValueFromQueryString("idMovil");
            ShamanContext db = new ShamanContext(Helper.getConnectionStringBySerial(license));
            ServicioDetalle svDetalle = db.Database.SqlQuery<ServicioDetalle>("sp_GetViaje @viajeId = {0},@movil = {1}", id,idMovil)
                                        .FirstOrDefault();

            return svDetalle;
        }

    }
}