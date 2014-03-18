using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Test.Model.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includeProperties);

        T GetByID(int id);

        void Insert(T entity);

        //void Insert(IList<T> entities);

        void Update(T entityToUpdate);

        void Delete(int id);

        void Delete(T entity);

    }
}
