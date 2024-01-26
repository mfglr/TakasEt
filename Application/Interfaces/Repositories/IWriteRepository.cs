using Models.Entities;

namespace Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> where T : IAggregateRoot
	{
		Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
		Task DeleteAsync(int id, CancellationToken cancellationToken);
	}
}
