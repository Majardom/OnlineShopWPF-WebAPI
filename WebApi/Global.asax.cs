using System.Web.Http;
using BLL.AutoMapperConfiguration;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Initialize();
        }
    }
}
