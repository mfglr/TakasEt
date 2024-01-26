namespace Application.Interfaces.Repositories
{
	public interface IReadRepository<T> where T: class
	{
		Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken);
	}
}
