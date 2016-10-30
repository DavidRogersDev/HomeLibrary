using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public class ExpressionBuilder : IExpressionBuilder
    {
        private const string Dot = ".";
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");

        private static MethodInfo startsWithMethod =
            typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });

        private static MethodInfo endsWithMethod =
            typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        public Expression<Func<T, TResult>> MakeSelector<T, TResult>(string path)
        {
            var item = Expression.Parameter(typeof(T), "item");
            var body = path.Split('.').Aggregate((Expression)item, Expression.PropertyOrField);
            return (Expression<Func<T, TResult>>)Expression.Lambda(body, item);
        }

        public Expression<Func<T, TResult>> GetExpressionSort<T, TResult>(string propertyToOrderBy)
        {
            var parameterExpression = Expression.Parameter(typeof(T), "t");
            var memberExpression = GetMember(parameterExpression, propertyToOrderBy);

            return (Expression<Func<T, TResult>>)Expression.Lambda(memberExpression, parameterExpression);
        }

        public Func<IQueryable<T>, IOrderedQueryable<T>> GetExpressionSortFunc<T, TResult>(
            string propertyToOrderBy,
            ListSortDirection listSortDirection)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "t");
            MemberExpression memberExpression = GetMember(parameterExpression, propertyToOrderBy);

            var lambda = (Expression<Func<T, TResult>>)Expression.Lambda(memberExpression, parameterExpression);

            switch (listSortDirection)
            {
                case ListSortDirection.Ascending:
                    return l => l.OrderBy(lambda);
                case ListSortDirection.Descending:
                    return l => l.OrderByDescending(lambda);
                default:
                    throw new NotSupportedException(string.Format("{0} is not a suppoted ListSortDirection", listSortDirection));
            }
        }

        public Expression<Func<T, bool>> MakePredicateAnd<T>(IEnumerable<Filter> filters)
        {
            if (filters == null)
                return null;

            filters = filters.Where(filter => filter != null);

            if (!filters.Any())
                return null;

            var item = Expression.Parameter(typeof(T), "t");

            var body = filters.Select(filter => MakePredicate<T>(item, filter)).Aggregate(Expression.AndAlso);

            var predicate = Expression.Lambda<Func<T, bool>>(body, item);

            return predicate;
        }
        public Expression<Func<T, bool>> MakePredicateOr<T>(IEnumerable<Filter> filters)
        {
            if (filters == null)
                return null;

            filters = filters.Where(filter => filter != null);

            if (!filters.Any())
                return null;

            var item = Expression.Parameter(typeof(T), "t");

            var body = filters.Select(filter => MakePredicate<T>(item, filter)).Aggregate(Expression.OrElse);

            var predicate = Expression.Lambda<Func<T, bool>>(body, item);

            return predicate;
        }

        private Expression MakePredicate<T>(ParameterExpression param, Filter filter)
        {
            MemberExpression member = GetMember(param, filter);

            if (typeof(IEnumerable<T>).IsAssignableFrom(member.Type))
                throw new NotSupportedException("The Property which is the attempted target of the filtering is an IEnumerable<T> and not supported by this API. Only reference Navigation Properties are supported i.e. non-collection.");

            ConstantExpression constant = Expression.Constant(filter.Value);

            switch (filter.Operation)
            {
                case Op.Equals:
                    return Expression.Equal(member, constant);

                case Op.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case Op.Contains:
                    return Expression.Call(member, containsMethod, constant);

                case Op.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case Op.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }


        private MemberExpression GetMember(ParameterExpression parameterExpression, Filter filter)
        {
            return GetMemberHelper(parameterExpression, filter.PropertyName);
        }

        private MemberExpression GetMember(ParameterExpression parameterExpression, string propertyName)
        {
            return GetMemberHelper(parameterExpression, propertyName);
        }

        private MemberExpression GetMemberHelper(ParameterExpression parameterExpression, string propertyName)
        {
            if (propertyName.Contains(Dot))
            {
                return Expression.Property(
                    GetMemberHelper(parameterExpression, propertyName.Substring(0, propertyName.LastIndexOf(Dot, System.StringComparison.Ordinal))),
                    propertyName.Substring(propertyName.LastIndexOf(Dot, System.StringComparison.Ordinal) + 1)
                    );
            }

            return Expression.Property(parameterExpression, propertyName);
        }
    }

}