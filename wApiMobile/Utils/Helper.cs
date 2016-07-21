using System;
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

        public static int getHoursFromTime(string time)
        {
            if (string.IsNullOrEmpty(time)) return 0;
            return Convert.ToInt32(time.Split(':')[0]);
        }

        public static int getMinutesFromTime(string time)
        {
            if (string.IsNullOrEmpty(time)) return 0;
            return Convert.ToInt32(time.Split(':')[1]);
        }
    }
}