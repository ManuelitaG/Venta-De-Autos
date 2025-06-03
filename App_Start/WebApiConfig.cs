using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using VentaAutos.Clases;

namespace VentaAutos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Habilitar CORS para todos los orígenes (útil para desarrollo)
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Registrar rutas de Web API
            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            // Agregar handler de validación de token (si lo usas)
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
