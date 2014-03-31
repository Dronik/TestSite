using System.Collections.Generic;
using PagedList;
using Test.Logic.Filters;
using Test.Model.Model;

namespace Test.Logic.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPersons();
        IPagedList<Person> GetPersonsFiltered(PersonFilter filter);
        Person GetPerson(int id);
        void CreatePerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}
