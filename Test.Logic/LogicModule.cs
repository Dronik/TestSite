using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Test.DataProvider;
using Test.Logic.Interfaces;
using Test.Logic.Services;

namespace Test.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IPersonService>().To<PersonService>();
        }
    }

    /// <summary>
    /// Used to hide a DVS.DataProvider.StorageModule to avoid it direct usage in WebSite.    
    /// </summary>
    public sealed class LogicStorageModule : NinjectModule
    {
        public override void Load()
        {
            StorageModule[] dbModules = new StorageModule[1] { new StorageModule() };
            this.Kernel.Load(dbModules);
        }
    }

}
