using System.Web.Mvc;
using System.Web.Routing;

namespace FirstApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstraper.Initialize();
        }
    }
}
