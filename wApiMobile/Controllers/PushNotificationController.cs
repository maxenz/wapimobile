using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace wApiMobile.Controllers
{
    public class PushNotificationController : ApiController
    {
        // GET api/pushnotification
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pushnotification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pushnotification
        public bool Post([FromBody]string nroMovil, [FromBody]string mensaje)
        {

            //string channel = "m" + nroMovil;

            //bool isPushMessageSend = false;

            //string postString = "";
            //string urlpath = "https://api.parse.com/1/push";
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);
            //postString = "{ \"channels\": [ \"" + nroMovil + "\"  ], " +
            //                 "\"data\" : {\"alert\":\"" + mensaje + "\"}" +
            //                 "}";
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.ContentLength = postString.Length;
            //httpWebRequest.Headers.Add("X-Parse-Application-Id", "Yu5MsVhQi7ih2ltKlNrQcrpFfvRlexZnGiecJZHd");
            //httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "oNEoeZZYe5JcfNwnSSBWGNc93uGxIkd5Kcl5gts4");
            //httpWebRequest.Method = "POST";
            //StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var responseText = streamReader.ReadToEnd();
            //    JObject jObjRes = JObject.Parse(responseText);
            //    if (Convert.ToString(jObjRes).IndexOf("true") != -1)
            //    {
            //        isPushMessageSend = true;
            //    }
            //}

            //return isPushMessageSend;

            return false;
        }






        // PUT api/pushnotification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pushnotification/5
        public void Delete(int id)
        {
        }
    }
}
