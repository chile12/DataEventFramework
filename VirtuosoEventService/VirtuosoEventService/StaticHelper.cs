using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtuosoEventService
{
    public class StaticHelper
    {
        public static string ServiceEndpointAddress = System.Configuration.ConfigurationManager.AppSettings.GetValues("endpointAddress")[0];
        public static string Namespace = "http://tempuri.org/";
    }
}