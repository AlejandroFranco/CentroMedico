using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CentroMedico
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Registro",
                url: "Registro",
                defaults: new { controller = "Registro", action = "Registro", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Paciente",
                url: "Home/Usuario",
                defaults: new { controller = "Paciente", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Perfil Paciente",
                url: "Home/Usuario/Perfil",
                defaults: new { controller = "Paciente", action = "Perfil", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Salir",
                url: "Salir",
                defaults: new { controller = "Paciente", action = "Salir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Editar Paciente",
                url: "Home/Usuario/Perfil/{action}/{id}",
                defaults: new { controller = "Paciente", action = "Editar", id = UrlParameter.Optional }
            );

        }
    }
}
