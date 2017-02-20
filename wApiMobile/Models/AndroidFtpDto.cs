using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class AndroidFtpDto
    {
        public string Dir { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string LocalFileDir { get; set; }

        public string License { get; set; }

        public string Mobile { get; set; }

        public string SpecificFolderName { get; set; }

        public string RemoteFileDir
        {
            get
            {
                return String.Format(@"{0}/AndroidUploads/{1}/{2}/{3}/", this.Dir, this.License, this.Mobile, this.SpecificFolderName);

            }
        }
    }
}