using Application.Dtos;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtentionsForPagination
	{
		public static IQueryable<TEntity> ToPage<TEntity>( this IQueryable<TEntity> queryable, IPage page) where TEntity : IEntity
		{
			var r = queryable.Where(x => page.LastId == null || x.GetKey()[0] < page.LastId).OrderByDescending(x => x.GetKey()[0]);
			if (page.Take != null)
				return r.Take((int)page.Take);
			return r.Take(10);
		}
	}
}
