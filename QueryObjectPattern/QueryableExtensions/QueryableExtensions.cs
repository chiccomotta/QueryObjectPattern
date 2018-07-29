using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QueryObjectPattern.QueryableExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, int property, Expression<Func<T, bool>> predicate)
        {
            if (property > 0)
            {
                return query.Where(predicate);
            }

            return query;
        }

        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, int? property, Expression<Func<T, bool>> predicate)
        {
            if (property.HasValue)
            {
                return query.Where(predicate);
            }

            return query;
        }      

        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, string property, Expression<Func<T, bool>> predicate)
        {
            if (!string.IsNullOrWhiteSpace(property))
            {
                return query.Where(predicate);
            }

            return query;
        }

        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, DateTime? date, Expression<Func<T, bool>> predicate)
        {
            if (date.HasValue)
            {
                return query.Where(predicate);
            }

            return query;
        }
    }
}
