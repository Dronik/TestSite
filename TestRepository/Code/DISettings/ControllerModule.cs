using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common;
using Test.WebSite.Controllers;

namespace Test.WebSite.Code.DISettings
{
    public class ControllerModule : Ninject.Modules.NinjectModule
	{
        public override void Load()
        {
            Bind<HomeController>().ToSelf().InRequestScope();
        }
	}
}