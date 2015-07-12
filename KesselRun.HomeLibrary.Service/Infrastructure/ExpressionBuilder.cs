using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public static class ExpressionBuilder
    {
        private const string Dot = ".";
        private static MethodInfo containsMethod = typeof (string).GetMethod("Contains");

        private static MethodInfo startsWithMethod =
            typeof (string).GetMethod("StartsWith", new Type[] {typeof (string)});

        private static MethodInfo endsWithMethod =
            typeof (string).GetMethod("EndsWith", new Type[] {typeof (string)});


        public static Expression<Func<T, bool>> GetExpression<T>(IList<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof (T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
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

        private static MemberExpression GetMember(ParameterExpression parameterExpression, Filter filter)
        {
            return GetMemberHelper(parameterExpression, filter.PropertyName);
        }

        private static MemberExpression GetMemberHelper(ParameterExpression parameterExpression, string propertyName)
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

        private static BinaryExpression GetExpression<T>
            (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }

    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }

    public class Filter
    {
        public string PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }

}