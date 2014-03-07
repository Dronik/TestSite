using System.Web.Mvc;
using Test.Logic.Interfaces;
using Test.Model.Model;
using WebApp.Code;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new PersonViewModel());
        }
    }
}