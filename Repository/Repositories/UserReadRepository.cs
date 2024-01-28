using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Contexts;

namespace Repository.Repositories
{
	public class UserReadRepository : ReadRepository<User>, IUserReadRepository
	{
		public UserReadRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<User> GetUserWithSignalRStateAsync(int userId, CancellationToken cancellationToken)
		{
			return await _dbSet
				.Include(x => x.UserSignalRState)
				.FirstAsync(x => x.Id == userId, cancellationToken);
		}
	}
}
