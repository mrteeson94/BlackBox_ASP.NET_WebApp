using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace blackBox
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes();


            //Maproute hardcoded
            //1.param 1 name of maproute
            //2.param 2 defined url path
            //3.param 3 constraints of the url
            //routes.MapRoute(
            //    "MovieReleaseDates",
            //    "movie/released/{year}/{month}",
            //    new {controller= "Movie", action="ByReleaseDates"}
            //    );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
