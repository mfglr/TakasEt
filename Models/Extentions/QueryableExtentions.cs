using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.Entities;

namespace Models.Extentions
{
	public static class QueryableExtentions
	{
		public static IIncludableQueryable<TRecursiveEntity, IReadOnlyCollection<TRecursiveEntity>>
			IncludeChildrenByRecursive<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int depth
		) where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Children);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Children);
			return query;
		}

		public static IIncludableQueryable<TRecursiveEntity, TRecursiveEntity>
			IncludeParentByRecursive<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int depth
		) where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Parent);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Parent);
			return query;
		}

		public static void RemoveRecursive<TRecuersiveEntity>(
			this DbSet<TRecuersiveEntity> dbSet,
			TRecuersiveEntity entity
			)
			where TRecuersiveEntity : RecursiveEntity<TRecuersiveEntity>
		{
			if (entity.Children != null)
			{
				foreach (var child in entity.Children)
				{
					RemoveRecursive(dbSet, child);
					dbSet.Remove(child);
				}
			}
			dbSet.Remove(entity);
		}

		public static void RemoveRangeRecursive<TRecuersiveEntity>(
			this DbSet<TRecuersiveEntity> dbSet,
			IReadOnlyCollection<TRecuersiveEntity> entities
			)
			where TRecuersiveEntity : RecursiveEntity<TRecuersiveEntity>
		{
			foreach(var entity in entities)
			{
				RemoveRecursive(dbSet, entity);
			}
		}

		public static IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>>
			ThenIncludeChildrenByRecursive<TEntity, TRecursiveEntity>(
			this IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> queryable,
			int depth
		)
			where TEntity : class
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.ThenInclude(x => x.Children);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Children);
			return query;
		}

		public static IIncludableQueryable<TEntity, TRecursiveEntity>
			ThenIncludeParentByRecursive<TEntity, TRecursiveEntity>(
			this IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> queryable,
			int depth
		)
			where TEntity : class
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.ThenInclude(x => x.Parent);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Parent);
			return query;
		}

		public static async Task<int> FindParentDepthAsync<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int maxDepth,
			int? parentId,
			CancellationToken cancellationToken
		)
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Children);
			for (int i = 2; i < maxDepth; i++)
				query = query.ThenInclude(x => x.Children);

			var entity = await queryable.SingleOrDefaultAsync(x => x.Id == parentId, cancellationToken);
			
			int depth = 0;
			var iter = entity;
			while(iter != null)
			{
				iter = iter.Parent;
				depth++;
			}
			return depth;
		}

		public static async Task<bool> AddRecursiveAsync<TRecursiveEntiy>(
			this DbSet<TRecursiveEntiy> dbset,
			int depth,
			TRecursiveEntiy entity,
			CancellationToken cancellationToken
		)
			where TRecursiveEntiy : RecursiveEntity<TRecursiveEntiy>
		{
			int parentDepth = await dbset.FindParentDepthAsync(depth, entity.ParentId, cancellationToken);
			if(parentDepth > depth ) return false;
			await dbset.AddAsync(entity, cancellationToken);
			return true;
		}
	}
}
