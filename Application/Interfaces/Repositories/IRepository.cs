using Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
		DbSet<T> DbSet { get; }
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		void Update(T entity);
		void Remove(T entity);
	} 
}
