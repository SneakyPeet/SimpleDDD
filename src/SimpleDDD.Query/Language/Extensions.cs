using System;
using System.Linq.Expressions;

namespace SimpleDDD.Query.Language
{
    public static class Extensions
    {
        public static Fetchable Where<T, TResult>(this Fetchable<T, TResult> fetchable, Expression<Func<TResult, bool>> expression) where T : Fetchable<T, TResult> 
        {
            fetchable.SetWhereClause(expression);
            return fetchable;
        }
    }
}