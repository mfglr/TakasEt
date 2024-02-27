using SharedLibrary.Dtos;
using SharedLibrary.Entities;

namespace SharedLibrary.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>( this IQueryable<TEntity> queryable, IPage page) where TEntity : IEntity
        {
			return queryable
				.Where(x => page.LastDate == null || x.CreatedDate < page.LastDate)
				.OrderByDescending(x => x.CreatedDate)
				.Take(page.Take != null ? (int)page.Take! : 10);
		}

	}
}
