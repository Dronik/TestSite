using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
