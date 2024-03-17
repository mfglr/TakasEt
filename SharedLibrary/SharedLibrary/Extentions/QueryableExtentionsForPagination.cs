using SharedLibrary.Dtos;
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
            where TEntity : class
            where TProperty : IComparable<TProperty>
        {

            var method = typeof(IComparable<TProperty>).GetMethod("CompareTo")!;
            var right = Expression.Constant(0);
            var left = Expression.Call(propertyForPagination.Body, method,Expression.Constant(page.LastValue));

            BinaryExpression body;
            if (page.IsDescending) body = Expression.LessThan(left, right);
            else body = Expression.GreaterThan(left, right);

            body = Expression.Or(
                    Expression.Equal(
                        Expression.Constant(page.LastValue),
                        Expression.Constant(default(TProperty))
                    ),
                    body
                );
                
            return queryable
                .Where(Expression.Lambda<Func<TEntity, bool>>(body, propertyForPagination.Parameters))
                .OrderByDescending(propertyForPagination)
                .Take(page.Take);
        }



        public static IQueryable<TEntity> ToPage<TEntity, TProperty>(
            this IQueryable<TEntity> queryable,
            Expression<Func<TEntity, TProperty>> propertyForPagination,
            Expression<Func<TEntity,TProperty>> thenByProperty,
            IPage<TProperty> page
        )
            where TEntity : class
            where TProperty : IComparable<TProperty>
        {

            var method = typeof(IComparable<TProperty>).GetMethod("CompareTo")!;
            var right = Expression.Constant(0);
            var left = Expression.Call(propertyForPagination.Body, method, Expression.Constant(page.LastValue));

            BinaryExpression body;
            if (page.IsDescending) body = Expression.LessThan(left, right);
            else body = Expression.GreaterThan(left, right);

            body = Expression.Or(
                    Expression.Equal(
                        Expression.Constant(page.LastValue),
                        Expression.Constant(default(TProperty))
                    ),
                    body
                );

            return queryable
                .Where(Expression.Lambda<Func<TEntity, bool>>(body, propertyForPagination.Parameters))
                .OrderByDescending(propertyForPagination)
                .ThenByDescending(thenByProperty)
                .Take(page.Take);
        }
    }
}
