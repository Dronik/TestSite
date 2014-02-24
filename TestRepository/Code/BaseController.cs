using System.Web.Mvc;
using Test.Model.Interfaces.IProviders;
using Test.WebSite.Code.DISettings;

namespace Test.WebSite.Code
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