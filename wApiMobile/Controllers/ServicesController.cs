using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using wApiMobile.Models;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
    public class ServicesController : ApiController
    {
        private ShamanContext db = new ShamanContext();

        private string cnnApp = ConfigurationManager.ConnectionStrings["cnnShaman"].ConnectionString;

        // GET api/<controller>
        public List<Servicio> Get()
        {
            string license = Helper.getValueFromQueryString("licencia");
            string idMovil = Helper.getValueFromQueryString("idMovil");
            List<Servicio> servicios = db.Database.SqlQuery<Servicio>("sp_GetViajesMovil @movil = {0}", idMovil).ToList<Servicio>();
            return servicios;
           
        }

        // GET api/<controller>/5
        public ServicioDetalle Get(int id)
        {
            string license = Helper.getValueFromQueryString("license");
            string idMovil = Helper.getValueFromQueryString("idMovil");
            ServicioDetalle svDetalle = db.Database.SqlQuery<ServicioDetalle>("sp_GetViaje @viajeId = {0},@movil = {1}", id,idMovil)
                                        .FirstOrDefault();

            return svDetalle;
        }

    }
}