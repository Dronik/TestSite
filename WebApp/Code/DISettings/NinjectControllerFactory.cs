using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Test.Model.Interfaces.IProviders;

namespace WebApp.Code.DISettings
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            ninjectKernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var result = ninjectKernel.Get(controllerType) as IController;
            var commitProviderContainer = result as ICommitProviderContainer;
            if (commitProviderContainer != null)
                commitProviderContainer.CommitProviderInstance = ninjectKernel.Get<ICommitProvider>();

            return result;
        }
    }

    public interface ICommitProviderContainer
    {
        ICommitProvider CommitProviderInstance { set; }
    }
}