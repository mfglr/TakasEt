using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace Repository.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : class
	{

		protected readonly DbSet<T> _dbSet;

		public ReadRepository(AppDbContext context)
		{
			_dbSet = context.Set<T>();
		}

		public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbSet.FindAsync(id, cancellationToken);
		}
	}
}
