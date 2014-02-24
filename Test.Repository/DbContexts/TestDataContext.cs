using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Test.Model.Interfaces;
using Test.Model.Model;
using Test.Model.Model.Mapping;

namespace Test.DataProvider.DbContexts
{
    public class TestDataContext : DbContext, IDatabaseContext
    {
        public TestDataContext() : base("TestContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }

    }

    
}
