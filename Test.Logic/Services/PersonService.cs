using System.Collections.Generic;
using System.Linq;
using PagedList;
using Test.Logic.Extensions;
using Test.Logic.Extensions.Filters;
using Test.Logic.Filters;
using Test.Logic.Interfaces;
using Test.Model.Interfaces.IRepositories;
using Test.Model.Model;

namespace Test.Logic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            var p = _personRepository.Get();
            return p;
        }

        public IPagedList<Person> GetPersonsFiltered(PersonFilter filter)
        {
            var a = _personRepository.GetQueryable().OrderBy(x => x.Id).ToPagedList(1, 5);
            var p = _personRepository.GetQueryable().ApplyFilter(filter).ToPagedList(filter.PageNumber ?? 1, filter.PageSize ?? 5);
            return p;
        }

        public Person GetPerson(int id)
        {
            var p = _personRepository.GetByID(id);
            return p;
        }

        public void CreatePerson(Person person)
        {
            _personRepository.Insert(person);
        }

        public Person UpdatePerson(Person person)
        {
            _personRepository.Update(person);
            return person;
        }

        public void DeletePerson(int id)
        {
            _personRepository.Delete(id);
        }
    }
}
