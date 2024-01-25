using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace Repository.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : Entity, IAggregateRoot
	{
		private readonly DbSet<T> _dbSet;
		
		public WriteRepository(AppDbContext context) => _dbSet = context.Set<T>();


        public async Task<T> CreateAsync(T entity,CancellationToken cancellationToken)
		{
			return (await _dbSet.AddAsync(entity)).Entity;
		}

		public async Task DeleteAsync(int id,CancellationToken cancellationToken)
		{
			T? entity = await _dbSet.FindAsync(id,cancellationToken);
			_dbSet.Remove(entity!);
		}
		
	}
}
