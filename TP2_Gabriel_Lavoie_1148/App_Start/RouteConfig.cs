using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TP2_Gabriel_Lavoie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Retard",
                url: "Retard",
                defaults: new { controller = "Livres", action = "Retard", id = UrlParameter.Optional }
                );


            routes.MapRoute(
                name: "Pret",
                url: "Pret",
                defaults: new { controller = "Livres", action = "Pret", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Membres",
                url: "Membres",
                defaults: new { controller = "Livres", action = "Membres", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Acceuil",
                url: "Acceuil",
                defaults: new { controller = "Livres", action = "Acceuil", id = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "CollectionLivres",
               url: "CollectionLivres",
               defaults: new { controller = "Livres", action = "CollectionLivres", id = UrlParameter.Optional }
               );


           routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Livres", action = "Acceuil", id = UrlParameter.Optional }
            );
        }
    }
}
