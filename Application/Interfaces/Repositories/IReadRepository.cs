using Application.Entities;

namespace Application.Interfaces.Repositories
{
	public interface IReadRepository<T> where T: Entity
	{
		Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken);
	}
}
