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
			if (option.Level < 2) throw new Exception("Level is not less than 2.");
			_option = option;
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			int level = await findLevelAsync(entity.ParentId);
			if (level + 1 >= _option.Level) throw new Exception("Entity registration failed. Out of level");
			await _dbSet.AddAsync(entity);
		}
		public async Task RemoveAsync(Guid id)
		{
			IIncludableQueryable<T, IReadOnlyCollection<T>> query = _dbSet.Include(x => x.Children);
			for (int j = 2; j < _option.Level; j++)
				query = query.ThenInclude(x => x.Children);
			var entity = await query.Where(x => x.Id == id).SingleOrDefaultAsync();
			_dbSet.Remove(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
		
		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Where(expression);
		}
		
		private async Task<int> findLevelAsync(Guid? parentId)
		{
			if (parentId == null) return 0;
			IIncludableQueryable<T, T> query = _dbSet.Include(x => x.Parent);
			for (int j = 2; j < _option.Level; j++)
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
