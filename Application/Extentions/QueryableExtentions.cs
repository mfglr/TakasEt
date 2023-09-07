using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Extentions
{
	public static class QueryableExtentions
	{
		public static IIncludableQueryable<TRecursiveEntity, IReadOnlyCollection<TRecursiveEntity>> IncludeChildrenByRecursive<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int depth
		) where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Children);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Children);
			return query;
		}

		public static IIncludableQueryable<TRecursiveEntity, TRecursiveEntity> IncludeParentByRecursive<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int depth
		) where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Parent);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Parent);
			return query;
		}

		public static IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> ThenIncludeChildrenByRecursive<TEntity, TRecursiveEntity>(
			this IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> queryable,
			int depth
		)
			where TEntity : Entity
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.ThenInclude(x => x.Children);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Children);
			return query;
		}

		public static IIncludableQueryable<TEntity, TRecursiveEntity> ThenIncludeParentByRecursive<TEntity, TRecursiveEntity>(
			this IIncludableQueryable<TEntity, IReadOnlyCollection<TRecursiveEntity>> queryable,
			int depth
		)
			where TEntity : Entity
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.ThenInclude(x => x.Parent);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Parent);
			return query;
		}

		public static async Task<int> FindParentDepthAsync<TRecursiveEntity>(
			this IQueryable<TRecursiveEntity> queryable,
			int depth,
			Guid? parentId
			)
			where TRecursiveEntity : RecursiveEntity<TRecursiveEntity>
		{
			var query = queryable.Include(x => x.Children);
			for (int i = 2; i < depth; i++)
				query = query.ThenInclude(x => x.Children);

			var entity = await queryable.SingleOrDefaultAsync(x => x.Id == parentId);
			
			int rdepth = 0;
			var iter = entity;
			while(iter != null)
			{
				iter = iter.Parent;
				rdepth++;
			}
			return rdepth;
		}

		public static async Task<bool> AddRecursiveAsync<TRecursiveEntiy>(
			this DbSet<TRecursiveEntiy> dbset,
			int depth,
			TRecursiveEntiy entity
			)
			where TRecursiveEntiy : RecursiveEntity<TRecursiveEntiy>
		{
			int parentDepth = await dbset.FindParentDepthAsync(depth, entity.ParentId);
			if(parentDepth > depth ) return false;
			await dbset.AddAsync(entity);
			return true;
		}

		public static void RemoveRecursiveAsync<TRecuersiveEntity>(
			this DbSet<TRecuersiveEntity> dbSet,
			TRecuersiveEntity entity
			)
			where TRecuersiveEntity : RecursiveEntity<TRecuersiveEntity>
		{
			if (entity.Children != null)
			{
				foreach (var child in entity.Children)
				{
					RemoveRecursiveAsync(dbSet,child);
					dbSet.Remove(child);
				}
			}
			dbSet.Remove(entity);
		}
	}
}
