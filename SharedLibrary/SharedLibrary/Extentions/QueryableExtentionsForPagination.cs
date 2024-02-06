using SharedLibrary.Dtos;
using SharedLibrary.Entities;

namespace SharedLibrary.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>( this IQueryable<TEntity> queryable, IPage page) where TEntity : Entity
		{
			return queryable
				.Where(x => page.LastId == null || x.Id < page.LastId)
				.OrderByDescending(x => x.Id)
				.Take(page.Take != null ? (int)page.Take! : 10);
		}

	}
}
