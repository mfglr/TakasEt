using Microsoft.EntityFrameworkCore;

namespace Models.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
		DbSet<T> DbSet { get; }
	} 
}
