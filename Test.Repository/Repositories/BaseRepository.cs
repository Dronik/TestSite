using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Test.Model.Interfaces;
using Test.Model.Interfaces.IRepositories;
using Test.Model.Model;

namespace Test.DataProvider.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        internal IDatabaseFactory _dbFactory;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
            this.dbSet = ((DbContext)dbFactory.GetContext()).Set<TEntity>();
        }

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    IQueryable<TEntity> query = GetQueryable(includeProperties);

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQueryable(includeProperties);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual IQueryable<TEntity> GetQueryable(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties == null) throw new ArgumentNullException("includeProperties");

            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties)
            {
                if (includeProperty == null) throw new ArgumentNullException("includeProperties", "Parameter <includeProperties> contain element that null reference.");
                var methodExpression = (includeProperty.Body as MemberExpression);
                if (methodExpression == null) throw new ArgumentException("Parameter <includeProperties> should contain only assign to property.");

                query = query.Include(GetPath(includeProperty));
            }

            return query;
        }

        private static string GetPath(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var name = GetPath(((MemberExpression)exp).Expression) ?? String.Empty;
                    if (name.Length > 0) name += ".";
                    return name + ((MemberExpression)exp).Member.Name;
                case ExpressionType.Convert:
                case ExpressionType.Quote:
                    return GetPath(((UnaryExpression)exp).Operand);
                case ExpressionType.Lambda:
                    return GetPath(((LambdaExpression)exp).Body);
                default:
                    return null;
            }
        }

        public virtual TEntity GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbFactory.GetContext().Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _dbFactory.GetContext().Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
