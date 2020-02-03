using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Minesweeper2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
             * Home Controller Route
             * Created by default
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Register Controller URL Route
            routes.MapRoute(
                name: "Register",
                url: "{Register}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );

            //Login Controller URL Route
            routes.MapRoute(
                name: "Login",
                url: "{Login}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            //Game Controller URL Route
            routes.MapRoute(
                name: "Game",
                url: "{Game}",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
