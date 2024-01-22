using Application.Dtos;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>( this IQueryable<TEntity> queryable, IPage page) where TEntity : IEntity
		{
			var r = queryable
				.Where(
					x => page.LastId == null || 
					x.Id < page.LastId
				)
				.OrderByDescending(x => x.Id);

			if (page.Take != null)
				return r.Take((int)page.Take);
			return r.Take(10);
		}
	}
}
