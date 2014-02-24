using Test.Model.Interfaces;
using Test.Model.Interfaces.IRepositories;
using Test.Model.Model;

namespace Test.DataProvider.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        { }
    }
}
