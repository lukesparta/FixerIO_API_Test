using System;
using System.Configuration;

namespace Fixerio
{
    public static class FixerConfig
    {
        public static readonly string baseURL = ConfigurationManager.AppSettings["base_url"];
        public static readonly string ApiKey = ConfigurationManager.AppSettings["api_key"];
        public static readonly string ApiUrlMod = ConfigurationManager.AppSettings["access_key_url_mod"];

    }
}
