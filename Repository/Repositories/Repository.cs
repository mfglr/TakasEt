using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace Repository.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{

		protected readonly SqlContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(SqlContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public DbSet<T> DbSet => _dbSet;
	}
}
