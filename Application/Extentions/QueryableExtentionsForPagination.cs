using Application.Dtos;
using Application.Entities;
using System.Linq.Expressions;

namespace Application.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>(
			this IQueryable<TEntity> queryable,
			Expression<Func<TEntity,Guid>> keySelector,
			Pagination pagination
		)
			where TEntity : IEntity
		{
			return queryable
				.OrderByDescending(x => x.CreatedDate)
				.ThenBy(keySelector)
				.Where(x => x.CreatedDate < pagination.getDateTime())
				.Skip(pagination.Skip)
				.Take(pagination.Take);
		}

		public static IQueryable<IGrouping<TKey, TSource>> ToPage<TKey, TSource>(
			this IQueryable<IGrouping<TKey, TSource>> queryable,
			Expression<Func<IGrouping<TKey,TSource>, Guid>> keySelector,
			Pagination pagination
		)
			where TKey : IEntity where TSource : IEntity
		{
			return queryable
				.OrderByDescending(x => x.Key.CreatedDate)
				.ThenBy(keySelector)
				.Where(x => x.Key.CreatedDate < pagination.getDateTime())
				.Skip(pagination.Skip)
				.Take(pagination.Take);
		} 
	}
}
