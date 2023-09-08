using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
		DbSet<T> DbSet { get; }
	} 
}
