using Ninject.Web.Common;
using WebApp.Controllers;

namespace WebApp.Code.DISettings
{
    public class ControllerModule : Ninject.Modules.NinjectModule
	{
        public override void Load()
        {
            Bind<HomeController>().ToSelf().InRequestScope();
            Bind<PersonsController>().ToSelf().InTransientScope();
        }
	}
}