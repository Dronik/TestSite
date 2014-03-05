using System.Web.Mvc;
using Test.Logic.Interfaces;
using Test.Model.Model;
using WebApp.Code;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: /Home/
        public ActionResult Index()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    var homeAddr = new Address
            //    {
            //        City = "Minsk"+i,
            //        Country = "Belarus" + i,
            //        Street = "Kuprevicha" + i,
            //        Zip = "12345" + i
            //    };

            //    var person = new Person
            //    {
            //        FirstName = "John" + i,
            //        LastName = "Malkovich" + i,
            //        Age = 41 + i,
            //        HomeAddress = homeAddr
            //    };
            //    _personService.CreatePerson(person);
            //    CommitProviderInstance.Commit();
            //}
            

            //person.FirstName = "Bob";
            //person.HomeAddress.Country = "Russia";
            //_personService.UpdatePerson(person);
            //CommitProviderInstance.Commit();

            //var p = _personService.GetPerson(2);

            //_personService.DeletePerson(p.Id);
            //CommitProviderInstance.Commit();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}