using System;
using System.Configuration;

namespace Utility
{
    public static class ApplicationSettings
    {
        public static string DefaultConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; }
        }

        public static byte PageSize
        {
            get { return Convert.ToByte(ConfigurationManager.AppSettings["PageSize"]); }
        }

        public static byte Count
        {
            get { return Convert.ToByte(ConfigurationManager.AppSettings["Count"]); }
        }

        public static string EmailFrom
        {
            get { return ConfigurationManager.AppSettings["fromemail"]; }
        }

        public static string SMTPHost
        {
            get { return ConfigurationManager.AppSettings["SMTPHost"]; }
        }

        public static int SMTPPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]); }
        }

        public static string SMTPUserName
        {
            get { return ConfigurationManager.AppSettings["SMTPUserName"]; }
        }

        public static string SMTPPassword
        {
            get { return ConfigurationManager.AppSettings["SMTPPassword"]; }
        }
    }
}
