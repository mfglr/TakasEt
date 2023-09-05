using Application.Entities;

namespace Application.Interfaces.Repositories
{
	public interface IUserRepository
	{
		Task RemoveUserWithArticlesWithCommentsAsync(User user);
		Task<User> GetUserWithArticlesWithCommentsByIdAsync(Guid id);
	}
}
