using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wApiMobile.Utils
{
    public static class Helper
    {
        public static string getValueFromQueryString(string key)
        {
            var query = HttpContext.Current.Request.QueryString;
            return query.GetValues(key)[0];
        }
    }
}