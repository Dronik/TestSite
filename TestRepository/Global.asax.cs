using System.Web.Mvc;
using System.Web.Routing;
using Test.WebSite.Code.DISettings;
using TestRepository;

namespace Test.WebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          //  ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
