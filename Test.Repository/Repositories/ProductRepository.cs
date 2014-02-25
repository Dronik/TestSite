using Test.Model.Interfaces;
using Test.Model.Interfaces.IRepositories;
using Test.Model.Model;

namespace Test.DataProvider.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        { }
    }
}
