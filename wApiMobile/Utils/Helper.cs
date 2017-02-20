using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using wApiMobile.Models;

namespace wApiMobile.Utils
{
    public static class Helper
    {
        public static string getValueFromQueryString(string key)
        {
            var query = HttpContext.Current.Request.QueryString;
            return query.GetValues(key)[0];
        }

        public static int getHoursFromTime(string time)
        {
            if (String.IsNullOrEmpty(time) || time == "null")
            {
                return 0;
            }

            return Convert.ToInt32(time.Split(':')[0]);
        }

        public static int getMinutesFromTime(string time)
        {
            if (String.IsNullOrEmpty(time) || time == "null")
            {
                return 0;
            }

            return Convert.ToInt32(time.Split(':')[1]);
        }

        public static string getConnectionStringBySerial(string serial)
        {
            var url = string.Format("{0}{1}", ConfigurationManager.AppSettings["GestionUrlCnnString"], serial);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                JObject cnnString = JObject.Parse(responseText);
                if (cnnString.Property("ConnectionString") != null)
                {
                    string cnn =  cnnString.Property("ConnectionString").Value.ToString();
                    cnn += ";MultipleActiveResultSets = True";
                    return cnn;
                }
            }

            return null;

        }

        public static string getServerConnectiongBySerial(string serial)
        {
            var url = string.Format("{0}{1}", ConfigurationManager.AppSettings["GestionUrlServerConnection"], serial);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                JObject cnnString = JObject.Parse(responseText);
                if (cnnString.Property("ConexionServidor") != null)
                {
                    string cnn = cnnString.Property("ConexionServidor").Value.ToString();
                    cnn += ";MultipleActiveResultSets = True";
                    return cnn;
                }
            }

            return null;

        }

    }
}