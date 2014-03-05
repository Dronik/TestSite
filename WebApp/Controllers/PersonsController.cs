using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Test.Logic.Interfaces;
using Test.Model.Model;
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
        [HttpGet]
        public ActionResult Index()
        {
            var pesonEntities = _personService.GetAllPersons();

            var res = Mapper.Map<IEnumerable<PersonViewModel>>(pesonEntities);

            return View(res);
        }

        [HttpPost]
        public ActionResult AddPerson(PersonViewModel newPerson)
        {
            if (!ModelState.IsValid)
            {
                //return View(newPerson);
            }

            var personEntity = Mapper.Map<Person>(newPerson);
            _personService.CreatePerson(personEntity);
            CommitProviderInstance.Commit();

            return new JsonResult();
        }

        [HttpPost]
        public ActionResult UpdatePerson(PersonViewModel person)
        {
            if (!ModelState.IsValid)
            {
                //return View(newPerson);
            }

            var personEntity = Mapper.Map<Person>(person);
            _personService.UpdatePerson(personEntity);
            CommitProviderInstance.Commit();

            return new JsonResult();
        }

        [HttpPost]
        public ActionResult DeletePerson(int personId)
        {
            _personService.DeletePerson(personId);
            CommitProviderInstance.Commit();

            return new JsonResult();
        }
    }
}