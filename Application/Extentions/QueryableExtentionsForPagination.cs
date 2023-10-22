using Application.Dtos;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>(
			this IQueryable<TEntity> queryable,
			Pagination pagination) where TEntity : IEntity
		{
			return queryable
				.OrderByDescending(x => x.CreatedDate)
				.ThenBy(x => x.Id)
				.Where(x => new DateTime(pagination.FirstQueryDate) < x.CreatedDate)
				.Skip(pagination.Skip)
				.Take(pagination.Take);
		}

		public static IQueryable<IGrouping<TKey, TSource>> ToPage<TKey, TSource>(
			this IQueryable<IGrouping<TKey?, TSource>> queryable,Pagination pagination)
			where TKey : IEntity where TSource : IEntity
		{
			return queryable
				.OrderByDescending(x => x.Key.CreatedDate)
				.ThenBy(x => x.Key.Id)
				.Where(x => new DateTime(pagination.FirstQueryDate) < x.Key.CreatedDate)
				.Skip(pagination.Skip)
				.Take(pagination.Take);
		} 
	}
}
