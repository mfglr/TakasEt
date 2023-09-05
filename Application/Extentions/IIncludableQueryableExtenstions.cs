using Application.Configurations;
using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Extentions
{
	public static class IIncludableQueryableExtenstions
	{
		public static async Task<TEntity> GetEntityWithRecursiveEntitiesAsync<TEntity,TRecursiveEntity>(this 
			IIncludableQueryable<TEntity,IReadOnlyCollection<TRecursiveEntity>> query,
			RecursiveRepositoryOptions option,
			Guid id)
			where TEntity : Entity
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var innerQuery = query.ThenInclude(x => x.Children);
			for (int i = 2; i < option.Depth; i++)
				innerQuery = innerQuery.ThenInclude(x => x.Children);
			return await innerQuery.SingleOrDefaultAsync(a => a.Id == id);
		}

		public static async Task<TEntity> GetEntityAsNoTrackingWithRecursiveEntitiesAsync<TEntity, TRecursiveEntity>(this
			IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> query,
			RecursiveRepositoryOptions option,
			Guid id)
			where TEntity : Entity
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var innerQuery = query.ThenInclude(x => x.Children);
			for (int i = 2; i < option.Depth; i++)
				innerQuery = innerQuery.ThenInclude(x => x.Children);
			return await innerQuery.AsNoTracking().SingleOrDefaultAsync(a => a.Id == id);
		}
	}
}
