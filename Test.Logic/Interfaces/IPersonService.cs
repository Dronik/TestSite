using System.Collections.Generic;
using Test.Model.Model;

namespace Test.Logic.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(int id);
        void CreatePerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int id);

    }
}
