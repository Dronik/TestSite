using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Test.Logic.Interfaces;
using WebApp.Code;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class PersonsController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        //
        // GET: /Persons/
        public ActionResult Index()
        {
            var pesonEntities = _personService.GetAllPersons();

            var res = Mapper.Map<IEnumerable<PersonViewModel>>(pesonEntities);

            return View(res);
        }
    }
}