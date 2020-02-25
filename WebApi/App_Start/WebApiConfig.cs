using System.Web.Http;
using WebApi.ExceptionsAttribute;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Enable access from another server
            config.EnableCors();
            //Set exception filters
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new FailedToFindExceptionAttribute());

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
