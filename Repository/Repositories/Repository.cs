using Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace Repository.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{

		protected readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public DbSet<T> DbSet => _dbSet;
	}
}
