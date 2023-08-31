using Application.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Contexts;

namespace Repository.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SqlContext _context;

		public UnitOfWork(SqlContext context)
		{
			_context = context;
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IEnumerable<T> GetEntities<T>() where T : class
		{
			return _context.ChangeTracker.Entries<T>().Select(x => x.Entity);
		}

		public IEnumerable<T> GetEntities<T>(Func<EntityEntry<T>, bool> expression) where T : class
		{
			return _context.ChangeTracker.Entries<T>().Where(expression).Select(x => x.Entity);
		}
	}
}
