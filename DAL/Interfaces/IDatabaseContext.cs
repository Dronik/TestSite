using System.Data.Entity.Infrastructure;

namespace Test.Model.Interfaces
{
    public interface IDatabaseContext
    {
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
