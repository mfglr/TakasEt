using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Application.Interfaces
{
	public interface IUnitOfWork
	{
		IEnumerable<T> GetEntities<T>() where T : class;
		IEnumerable<T> GetEntities<T>(Func<EntityEntry<T>, bool> expression) where T : class;
		Task CommitAsync();
	}
}
