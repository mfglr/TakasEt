using Application.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		void Update(T entity);
		void Remove(T entity);
	} 
}
