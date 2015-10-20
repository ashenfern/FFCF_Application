using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace FFC.Framework.WebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "ApiByAction",
              routeTemplate: "api/{controller}/{action}/{day}/{productId}/{start}/{end}",
              defaults: new { id = RouteParameter.Optional }
          );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌ferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
