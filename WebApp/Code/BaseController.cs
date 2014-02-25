using System.Web.Mvc;
using Test.Model.Interfaces.IProviders;
using WebApp.Code.DISettings;

namespace WebApp.Code
{
    public class BaseController : Controller, ICommitProviderContainer
    {
        public ICommitProvider CommitProviderInstance
        {
            get;
            set;
        }
    }
}