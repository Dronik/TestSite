using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Test.Logic.Extensions;
using Test.Logic.Filters;
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
        public PartialViewResult GetPersons(PersonsListFilterViewModel filterViewModel, int? page)
        {
            var filter = Mapper.Map<PersonFilter>(filterViewModel);
            filter.PageSize = 5;

            if (page.HasValue)
            {
                filter.PageNumber = page.Value;
            }

            var pesonEntities = _personService.GetPersonsFiltered(filter);
            var res = pesonEntities.ToMappedPagedList<Person, PersonViewModel>();

            if (page.HasValue)
            {
                filterViewModel.PageNumber = page.Value;
            }


            var viewModel = new PersonsListViewModel()
          {
              Items = res,
              Filter = filterViewModel
          };

            ModelState.Clear();

            return PartialView("_ListOfPersons", viewModel);
        }

        [HttpPost]
        public ActionResult ApplyFilter([Bind(Prefix = "Filter")]PersonsListFilterViewModel model)
        {
            return RedirectToAction("GetPersons", model);
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