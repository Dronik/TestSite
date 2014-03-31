using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Logic.Filters;
using Test.Logic.Helpers;
using Test.Model.Model;

namespace Test.Logic.Extensions.Filters
{
    public static class FilterExtensions
    {
        public static IQueryable<Person> ApplyFilter(this IQueryable<Person> query, PersonFilter filter)
        {
            if (filter == null) throw new ArgumentNullException();

            var where = PredicateBuilder.True<Person>();


            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                where = where.AndAlso(x => x.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                where = where.AndAlso(x => x.LastName.Contains(x.LastName));
            }

            //if (filter.Age != null)
            //{
            //    where = where.AndAlso(x => x.Age == filter.Age);
            //}

            Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null;

            if (!string.IsNullOrEmpty(filter.SortColumn))
            {
                if (filter.IsAscending)
                {
                    switch (filter.SortColumn)
                    {
                        case "FirstName":
                            orderBy = i => i.OrderBy(x => x.FirstName);
                            break;
                        case "LastName":
                            orderBy = i => i.OrderBy(x => x.LastName);
                            break;
                        case "Age":
                            orderBy = i => i.OrderBy(x => x.Age);
                            break;
                        default:
                            throw new NotSupportedException("Unknow Column Name");
                    }
                }
                else
                {
                    switch (filter.SortColumn)
                    {
                        case "FirstName":
                            orderBy = i => i.OrderByDescending(x => x.FirstName);
                            break;
                        case "LastName":
                            orderBy = i => i.OrderByDescending(x => x.LastName);
                            break;
                        case "Age":
                            orderBy = i => i.OrderByDescending(x => x.Age);
                            break;
                        default:
                            throw new NotSupportedException("Unknow Column Name");
                    }
                }
            }

            return query.ApplyFilter(where, orderBy);
        }

        public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

    }
}
