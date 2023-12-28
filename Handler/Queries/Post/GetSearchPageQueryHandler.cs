using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetSearchPageQueryHandler : IRequestHandler<GetSearchPagePosts, AppResponseDto>
	{

		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Post> _posts;
		private readonly IRepository<User> _users;

		public GetSearchPageQueryHandler(LoggedInUser loggedInUser, IRepository<Post> posts, IRepository<User> users)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetSearchPagePosts request, CancellationToken cancellationToken)
		{
			var categorIds = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.UserPostExplorings)
				.ThenInclude(x => x.Post)
				.ThenInclude(x => x.Tags)
				.Where(x => x.Id == _loggedInUser.UserId)
				.Select(
					x => x.UserPostExplorings.OrderByDescending(x => x.Id).Take(5).Select(x => x.Post.CategoryId)
				)
				.FirstAsync();

			var posts = await _posts	
				.DbSet
				.IncludePost()
				.Where( post => categorIds.Count() == 0 || categorIds.Contains(post.CategoryId) )
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
