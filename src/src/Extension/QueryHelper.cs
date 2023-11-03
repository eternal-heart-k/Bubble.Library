using System;
using System.Linq;
using System.Linq.Expressions;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// 查询相关
    /// </summary>
    public static class QueryHelper
    {
        /// <summary>
        /// 条件过滤，真：过滤；假：不变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            CheckHelper.NotNull(query, nameof(query));
            return condition ? query.Where(predicate) : query;
        }
    }
}
