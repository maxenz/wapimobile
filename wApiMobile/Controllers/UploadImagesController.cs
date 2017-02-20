using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using wApiMobile.Utils;
using System.IO;
using wApiMobile.Models;
using wApiMobile.Classes;

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

                var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ? System.Web.HttpContext.Current.Request.Files[0] : null;

                if (file != null && file.ContentLength > 0)
                {
                    var form = HttpContext.Current.Request.Form;

                    string mobileNumber = form["mobileNumber"];
                    string license = form["license"];
                    string incidentId = form["incidentId"];

                    FtpManager.Upload(file, uploadPath, license, mobileNumber, incidentId, "Images");
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