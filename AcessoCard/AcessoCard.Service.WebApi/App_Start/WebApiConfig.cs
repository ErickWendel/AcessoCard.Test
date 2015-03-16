using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AcessoCard.Service.WebApi.Filters;

namespace AcessoCard.Service.WebApi.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new BasicAuthAttribute());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
