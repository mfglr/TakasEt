using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetHomePagePostsQueryHandler : IRequestHandler<GetHomePagePosts, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;

		public GetHomePagePostsQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetHomePagePosts request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.User)
				.ThenInclude(x => x.UserImages)
				.Include(x => x.User)
				.ThenInclude(x => x.Followers)
				.Include(x => x.PostImages)
				.Include(x => x.Tags)
				.ThenInclude(x => x.Tag)
				.Where( x => (x.User.Followers.Any(x => x.FollowerId == _loggedInUser.UserId)) )
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
