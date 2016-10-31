using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using wApiMobile.Utils;
using System.IO;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class UploadImagesController : ApiController
    {

        public HttpResponseMessage Post()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
                Directory.CreateDirectory(uploadPath);

                var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

                if (file != null && file.ContentLength > 0)
                {
                    var form = HttpContext.Current.Request.Form;

                    string mobileNumber = form["mobileNumber"];
                    string license = form["license"];
                    var fileName = String.Format("{0}_{1}.jpg", mobileNumber, DateTime.Now.ToFileTimeUtc().ToString());

                    var path = Path.Combine(
                        uploadPath,
                        fileName
                    );

                    file.SaveAs(path);
           
                    AndroidFtpDto ftpData = Helper.getAndroidFtpData(license);
                    ftpData.LocalFileDir = @path;
                    ftpData.License = license;
                    ftpData.Mobile = mobileNumber;
                    Helper.UploadToFtp(ftpData);
                    if (File.Exists(@path))
                    {
                        File.Delete(@path);
                    }
                }

                return new HttpResponseMessage(HttpStatusCode.OK);

            }

            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(e.Message)
                };
            }

        }
    }
}