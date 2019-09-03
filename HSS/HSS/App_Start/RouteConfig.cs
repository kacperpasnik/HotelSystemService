using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HSS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "AddReservation",
                 url: "reservation-add",
                 defaults: new { controller = "AddReservation", action = "Add" });

            routes.MapRoute(
                 name: "ManageReservation",
                 url: "reservation-manage",
                 defaults: new { controller = "Manage", action = "Manage" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
