using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class ServiciosController : ApiController
    {
        // GET api/<controller>
        public List<Servicio> Get()
        {
            List<Servicio> lstServ = new List<Servicio>();
            Servicio serv = new Servicio("126644", "4KL", 1, "M", 21, "Cabildo 5698", "OSDE", "15:23");
            Servicio serv2 = new Servicio("887644", "L2L", 2, "F", 10, "Santo Tome 5118", "MEDICUS", "11:23");
            Servicio serv3 = new Servicio("422644", "98G", 3, "M", 44, "Lacroze 1134", "OSDE", "09:15");
            lstServ.Add(serv);
            lstServ.Add(serv2);
            lstServ.Add(serv3);
            return lstServ;
           
        }

        // GET api/<controller>/5
        public Servicio Get(int id)
        {
            return null;
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