using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Owin;
using System.Web.Http.Cors;


namespace BackLibreria
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
