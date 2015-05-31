using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
    public class PushMessagesController : ApiController
    {
        public bool Get(string license, string mobileNumber, string message, string appId, string apiKey)
        {
            try
            {
                string channel = "m" + mobileNumber;

                bool isPushMessageSend = false;
                string postString = "";
                string urlpath = "https://api.parse.com/1/push";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);
                postString = "{ \"channels\": [ \"" + channel + "\"  ], " +
                                 "\"data\" : {\"alert\":\"" + message + "\"}" +
                                 "}";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = postString.Length;
                httpWebRequest.Headers.Add("X-Parse-Application-Id", appId);
                httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", apiKey);
                httpWebRequest.Method = "POST";
                StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    JObject jObjRes = JObject.Parse(responseText);
                    if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                    {
                        isPushMessageSend = true;
                    }
                }

                return isPushMessageSend;
            }
            catch
            {
                return false;
            }
                     
        }
    }
}
