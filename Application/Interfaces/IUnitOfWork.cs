using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Interfaces
{
	public interface IUnitOfWork
	{
		IEnumerable<T> GetEntities<T>(Func<EntityEntry<T>, bool> expression) where T : class;
		Task CommitAsync();
		bool HasChanges();
	}
}
