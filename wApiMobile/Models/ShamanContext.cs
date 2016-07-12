using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wApiMobile.Models
{
    public class ShamanContext : DbContext
    {
        public ShamanContext()
            : base("name = cnnShaman")
        {
        }

    }
}