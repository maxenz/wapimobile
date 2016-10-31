using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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

        public static AndroidFtpDto getAndroidFtpData(string serial)
        {
            var url = string.Format("{0}{1}", ConfigurationManager.AppSettings["GestionUrlAndroidFtp"], serial);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                JObject data = JObject.Parse(responseText);
                if (data.Property("Error") != null)
                {
                    return null;
                }

                return new AndroidFtpDto()
                {
                    Dir = data.Property("FtpAndroidDir").Value.ToString(),
                    User = data.Property("FtpAndroidUser").Value.ToString(),
                    Password = data.Property("FtpAndroidPassword").Value.ToString()
                };          
           
            }

        }

        public static void UploadToFtp(AndroidFtpDto ftpData)
        {
            string path = string.Format(@"AndroidUploads/{0}/{1}", ftpData.License, ftpData.Mobile);
            MakeFTPDir(ftpData, path);

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpData.User, ftpData.Password);
                client.UploadFile(ftpData.RemoteFileDir + new FileInfo(ftpData.LocalFileDir).Name, "STOR", ftpData.LocalFileDir);
            }
        }

        private static void MakeFTPDir(AndroidFtpDto ftpData, string pathToCreate)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            string[] subDirs = pathToCreate.Split('/');

            string currentDir =  ftpData.Dir;

            foreach (string subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpData.User, ftpData.Password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {
                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                }
            }
        }

    }
}