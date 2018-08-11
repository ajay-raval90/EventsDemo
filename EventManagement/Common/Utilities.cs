using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EventManagement.Common
{
    public static class Utilities
    {
        public static string ConfigString(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return "";
            }
        }

        public static bool ConfigBool(string key)
        {
            try
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
            }
            catch
            {
                return false;
            }
        }

        public static int ConfigInt(string key)
        {
            return ConfigInt(key, 0);
        }

        public static int ConfigInt(string key, int? defaultValue)
        {
            int rtn = defaultValue.GetValueOrDefault();
            try
            {
                Int32.TryParse(ConfigurationManager.AppSettings[key], out rtn);
            }
            catch
            {
                rtn = defaultValue.GetValueOrDefault();
            }
            if (rtn == 0 && defaultValue.GetValueOrDefault() > 0)
            {
                return defaultValue.GetValueOrDefault();
            }
            return rtn;
        }

    }
}