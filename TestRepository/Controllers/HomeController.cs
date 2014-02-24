using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Logic.Interfaces;
using Test.Model.Model;
using Test.WebSite.Code;

namespace Test.WebSite.Controllers
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
            var homeAddr = new Address
            {
                City = "Minsk",
                Country = "Belarus",
                Street = "Kuprevicha",
                Zip = "12345"
            };

            var person = new Person
            {
                FirstName = "John", 
                LastName = "Malkovich", 
                Age = 41, 
                HomeAddress = homeAddr
            };
            _personService.CreatePerson(person);
            CommitProviderInstance.Commit();

            person.FirstName = "Bob";
            person.HomeAddress.Country = "Russia";
            _personService.UpdatePerson(person);
            CommitProviderInstance.Commit();

            var p = _personService.GetPerson(2);

            _personService.DeletePerson(p.Id);
            CommitProviderInstance.Commit();

            return View();
        }
    }
}