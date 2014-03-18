using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Test.Logic.Extensions;
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

        [HttpGet]
        public ActionResult Index()
        {
            // var pesonEntities = _personService.GetAllPersons();

            // var res = Mapper.Map<IEnumerable<PersonViewModel>>(pesonEntities);

            return View();
        }

        [HttpGet]
        public PartialViewResult GetPersons(int? page)
        {
            var pageNumber = page ?? 1;
            var pesonEntities = _personService.GetPersonsPaged(pageNumber);
            var res = pesonEntities.ToMappedPagedList<Person, PersonViewModel>();

            // var res = Mapper.Map<IEnumerable<PersonViewModel>>(pesonEntities);

            return PartialView("_ListOfPersons", res);
        }

        [HttpPost]
        public ActionResult AddPerson(PersonViewModel newPerson)
        {
            if (!ModelState.IsValid)
            {
                //   return View(newPerson);
            }


            var personEntity = Mapper.Map<Person>(newPerson);
            _personService.CreatePerson(personEntity);
            CommitProviderInstance.Commit();

            return RedirectToAction("GetPersons");

        }

        [HttpGet]
        public ActionResult UpdatePerson(int personId)
        {
            var personEntity = _personService.GetPerson(personId);
            var personModel = Mapper.Map<PersonViewModel>(personEntity);

            return PartialView("_EditPersonView", personModel);
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

            return RedirectToAction("GetPersons");
        }

        // [HttpPost]
        public ActionResult DeletePerson(int personId)
        {

            if (HttpContext.Request.IsAjaxRequest())
            {

            }
            _personService.DeletePerson(personId);
            CommitProviderInstance.Commit();

            return RedirectToAction("GetPersons");

        }
    }
}