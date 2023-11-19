using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByFollowedUsersQueryHandler : IRequestHandler<GetPostsByFollowedUsers, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;

		public GetPostsByFollowedUsersQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetPostsByFollowedUsers request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.User)
				.ThenInclude(x => x.ProfileImages)
				.Include(x => x.User)
				.ThenInclude(x => x.Followers)
				.Where(
					x =>
						(x.CreatedDate < request.getQueryDate()) && 
						(x.User.Followers.Any(x => x.FollowerId == _loggedInUser.UserId))
				)
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto()
				.ToListAsync(cancellationToken);

			return AppResponseDto.Success(posts);
		}
	}
}
