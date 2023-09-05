using Application.Configurations;
using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Contexts;
using System.Linq.Expressions;

namespace Repository.Repositories
{
	public class RecursiveRepository<T> : IRecursiveRepository<T> where T : RecursiveEntity<T>
	{
		private readonly RecursiveRepositoryOptions _option;
		private readonly SqlContext _context;
		private readonly DbSet<T> _dbSet;

		public RecursiveRepository(RecursiveRepositoryOptions option, SqlContext context)
		{
			if (option.Depth < 2) throw new Exception("Depth is not less than 2.");
			_option = option;
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			int depth = await findDepthAsync(entity.ParentId);
			if (depth + 1 >= _option.Depth) throw new Exception("Entity registration failed. Out of Max Depth");
			await _dbSet.AddAsync(entity);
		}
		
		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
		
		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			var query = _dbSet.Include(x => x.Children);
			for (int j = 2; j < _option.Depth; j++)
				query = query.ThenInclude(x => x.Children);
			return query.Where(expression);
		}

		public void Remove(T entity)
		{
			if(entity.Children != null) {
				foreach (var child in entity.Children)
				{
					Remove(child);
					_dbSet.Remove(child);
				}
			}
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IReadOnlyCollection<T> entities)
		{
			foreach(var entity in entities)
				Remove(entity);
		}

		private async Task<int> findDepthAsync(Guid? parentId)
		{
			if (parentId == null) return 0;
			IIncludableQueryable<T, T> query = _dbSet.Include(x => x.Parent);
			for (int j = 2; j < _option.Depth; j++)
				query = query.ThenInclude(x => x.Parent);
			
			var parents = await query.Where(x => x.Id == parentId).SingleOrDefaultAsync();
			T parentIterator = parents.Parent;
			int i = 0;
			while (parentIterator != null) { 
				i++;
				parentIterator = parentIterator.Parent;
			}
			return i;
		}
	}
}
