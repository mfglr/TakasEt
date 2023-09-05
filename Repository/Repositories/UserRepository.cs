using Application.Configurations;
using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IArticleRepository _articleRepository;
		private readonly UserManager<User> _userManager;
		private readonly RecursiveRepositoryOptions _option;

		public UserRepository(IArticleRepository articleRepository, UserManager<User> userManager, RecursiveRepositoryOptions option)
		{
			_articleRepository = articleRepository;
			_userManager = userManager;
			_option = option;
		}

		public async Task RemoveUserWithArticlesWithCommentsAsync(User user)
		{
			if (user.Articles != null)
				_articleRepository.RemoveArticlesWithComments(user.Articles);
			await _userManager.DeleteAsync(user);
		}

		public async Task<User> GetUserWithArticlesWithCommentsByIdAsync(Guid id)
		{
			var query = _userManager.Users
				.Include(x => x.Articles)
				.ThenInclude(a => a.Comments)
				.GetEntities
		}
	}
}
