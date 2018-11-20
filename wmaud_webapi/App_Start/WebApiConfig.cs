using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace wmaud_webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Configuracion que permite que todas las respuestas por defecto sean el formato json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //SE declara que las rutas van a ser declaradas por atributos y no por la forma convencional
            config.MapHttpAttributeRoutes();
            //Ruta para acceder a la api donde se indica que el parametro de fechaInicio y recepcion son opcionales
            config.Routes.MapHttpRoute(
                name: "wmaud",
                routeTemplate: "api/{controller}/{fechaInicio}/{recepcion}/",
                defaults: new { fechaInicio = RouteParameter.Optional, recepcion = RouteParameter.Optional}
            );
            
            config.Routes.MapHttpRoute(
                 name: "activofijo",
                 routeTemplate: "api/{controller}/{codigo}/{categoria}",
                 defaults: new { codigo = RouteParameter.Optional, categoria = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
