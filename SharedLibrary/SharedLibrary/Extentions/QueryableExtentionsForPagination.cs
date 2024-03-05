using SharedLibrary.Dtos;
using SharedLibrary.Entities;
using System.Linq.Expressions;

namespace SharedLibrary.Extentions
{
    public static class QueryableExtentionsForPagination
    {

        public static IQueryable<TEntity> ToPage<TEntity, TProperty>(
            this IQueryable<TEntity> queryable,
            Expression<Func<TEntity, TProperty>> propertyForPagination,
            IPage<TProperty> page
		)
            where TEntity : IEntity
            where TProperty : IComparable<TProperty>
        {

            var method = typeof(IComparable<TProperty>).GetMethod("CompareTo")!;
            var right = Expression.Constant(0);
            var left = Expression.Call(
                propertyForPagination.Body, 
                method,
                Expression.Constant(page.LastValue)
            );
            
            if (page.IsDescending)
                return queryable
                    .Where(
                        Expression.Lambda<Func<TEntity, bool>>(
                            Expression.LessThan(left, right),
                            propertyForPagination.Parameters
                       )
                    )
                    .OrderByDescending(propertyForPagination)
                    .Take(page.Take);

            return queryable
                .Where(
                    Expression.Lambda<Func<TEntity, bool>>(
                        Expression.GreaterThan(left, right),
                        propertyForPagination.Parameters
                    )
                )
                .OrderBy(propertyForPagination)
                .Take(page.Take);
        }
    }
}
