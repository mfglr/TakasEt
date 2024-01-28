using Models.Entities;

namespace Application.Interfaces.Repositories
{
	public interface IUserReadRepository : IReadRepository<User>
	{
		Task<User> GetUserWithSignalRStateAsync(int userId,CancellationToken cancellationToken);
	}
}
