using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Wingtiptoys.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
            new { id = RouteParameter.Optional });
        }
    }
}
