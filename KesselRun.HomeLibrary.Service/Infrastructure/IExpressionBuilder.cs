using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface IExpressionBuilder
    {
        Expression<Func<T, TResult>> MakeSelector<T, TResult>(string path);
        Expression<Func<T, TResult>> GetExpressionSort<T, TResult>(string propertyToOrderBy);

        Func<IQueryable<T>, IOrderedQueryable<T>> GetExpressionSortFunc<T, TResult>(
            string propertyToOrderBy,
            ListSortDirection listSortDirection);

        Expression<Func<T, bool>> MakePredicateAnd<T>(IEnumerable<Filter> filters);
        Expression<Func<T, bool>> MakePredicateOr<T>(IEnumerable<Filter> filters);
    }
}
