using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MyBooks.Entity.Global
{
    public static class GlobalVariables
    {
        public static string UserName { get; set; }
        public static string apiBaseUrl { get; set; }
        public static bool useWebApi { get; set; }

        public static void setGlobalVariable(string uname, IConfiguration config)
        {
            UserName = uname;
            apiBaseUrl = config["webapiurl"];
            var usewebApi = config["Usewebapi"];
            bool.TryParse(usewebApi, out bool callApi);
            useWebApi = callApi ? true : false;

        }
    }
}
