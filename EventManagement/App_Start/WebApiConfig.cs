using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace EventManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Action API Default
            config.Routes.MapHttpRoute(
                name: "DefaultActionApi",
                routeTemplate: "api/{controller}/action/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            JsonMediaTypeFormatter formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.Formatting = Formatting.Indented;
            formatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;


        }
    }
}
