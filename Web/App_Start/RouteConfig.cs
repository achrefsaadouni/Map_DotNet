using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "DetailResource",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Resource", action = " DetailResource", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "ListeResource",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Resource", action = "listeResource", id = UrlParameter.Optional }
         );



        }
    }
}
