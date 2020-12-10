using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wingtiptoys.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Products", action = "Get", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{id}/{product}",
                defaults: new { controller = "Products", action = "SearchProducts", id = UrlParameter.Optional, product = UrlParameter.Optional }
            );
        }
    }
}
