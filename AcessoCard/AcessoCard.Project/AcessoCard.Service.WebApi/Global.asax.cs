using System.Web.Http;
using AcessoCard.Service.WebApi.App_Start;

namespace AcessoCard.Service.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }
    }
}
