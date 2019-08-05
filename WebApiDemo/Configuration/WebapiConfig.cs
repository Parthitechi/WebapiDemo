using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiDemo.Configuration
{
    public static class WebapiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //AboutCrossOriginResource 
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}