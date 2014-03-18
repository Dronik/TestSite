using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Test.Model.Interfaces.IProviders;

namespace WebApp.Code.DISettings
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _ninjectKernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var result = _ninjectKernel.Get(controllerType) as IController;
            var commitProviderContainer = result as ICommitProviderContainer;
            if (commitProviderContainer != null)
                commitProviderContainer.CommitProviderInstance = _ninjectKernel.Get<ICommitProvider>();

            return result;
        }
    }

    public interface ICommitProviderContainer
    {
        ICommitProvider CommitProviderInstance { set; }
    }
}