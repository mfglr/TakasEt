using Application.Dtos;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>(
			this IQueryable<TEntity> queryable,
			Pagination pagination
		)
			where TEntity : IEntity
		{
			return queryable
				.Where(x => pagination.LastId == null || x.Id < pagination.LastId)
				.OrderByDescending( x => x.Id )
				.Skip(pagination.Skip)
				.Take(pagination.Take);
		}
	}
}
