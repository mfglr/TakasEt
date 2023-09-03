using Application.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
	public interface IRecursiveRepository<T> where T : RecursiveEntity<T>
	{
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		void Update(T entity);
		Task RemoveAsync(Guid id);
	}
}
