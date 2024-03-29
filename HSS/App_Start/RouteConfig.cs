﻿using System;
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
                 url: "add-reservation",
                 defaults: new { controller = "AddReservation", action = "Add" });

            routes.MapRoute(
                 name: "ManageReservation",
                 url: "manage-reservation",
                 defaults: new { controller = "Manage", action = "Manage" });

            routes.MapRoute(
                 name: "Register",
                 url: "register",
                 defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                 name: "Login",
                 url: "login",
                 defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
