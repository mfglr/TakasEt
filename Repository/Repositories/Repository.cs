using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System.Linq.Expressions;

namespace Repository.Repositories
{
	public class Repository<T> : IRepository<T> where T : Entity
	{

		protected readonly SqlContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(SqlContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Remove(T entity)
		{
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
	}
}
