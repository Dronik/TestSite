using Ninject.Modules;
using Ninject.Web.Common;
using Test.DataProvider.DbFactories;
using Test.DataProvider.Providers;
using Test.DataProvider.Repositories;
using Test.Model.Interfaces;
using Test.Model.Interfaces.IProviders;
using Test.Model.Interfaces.IRepositories;

namespace Test.DataProvider
{
    public class StorageModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
            Bind<ICommitProvider>().To<CommitProvider>().InRequestScope();

            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}
