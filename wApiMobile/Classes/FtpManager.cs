using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using wApiMobile.Models;

namespace wApiMobile.Classes
{
    public static class FtpManager
    {
        private static AndroidFtpDto getAndroidFtpData(string serial)
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

        private static void UploadToFtp(AndroidFtpDto ftpData)
        {
            string path = string.Format(@"AndroidUploads/{0}/{1}/{2}/", ftpData.License, ftpData.Mobile, ftpData.SpecificFolderName);
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

            string currentDir = ftpData.Dir;

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

        public static void Upload(HttpPostedFile file, string uploadPath, string license, string mobile, string incidentId, string specificFolder)
        {

            string extension = specificFolder == "Images" ? "png" : "3gpp";

            var fileName = string.Format("{0}_{1}.{2}", incidentId, DateTime.Now.ToFileTimeUtc().ToString(), extension);

            var path = Path.Combine(
                uploadPath,
                fileName
            );

            file.SaveAs(path);

            AndroidFtpDto ftpData = getAndroidFtpData(license);
            ftpData.LocalFileDir = @path;
            ftpData.License = license;
            ftpData.Mobile = mobile;
            ftpData.SpecificFolderName = specificFolder;
            UploadToFtp(ftpData);
            if (File.Exists(@path))
            {
                File.Delete(@path);
            }
        }
    }
}