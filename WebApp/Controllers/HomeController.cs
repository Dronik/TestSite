using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Logic.Interfaces;
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
            //var homeAddr = new Address
            //{
            //    City = "Minsk",
            //    Country = "Belarus",
            //    Street = "Kuprevicha",
            //    Zip = "12345"
            //};

            //var person = new Person
            //{
            //    FirstName = "John", 
            //    LastName = "Malkovich", 
            //    Age = 41, 
            //    HomeAddress = homeAddr
            //};
            //_personService.CreatePerson(person);
            //CommitProviderInstance.Commit();

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