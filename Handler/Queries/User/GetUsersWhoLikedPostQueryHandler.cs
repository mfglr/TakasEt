using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetUsersWhoLikedPostQueryHandler : IRequestHandler<GetUsersWhoLikedPost, AppResponseDto>
	{
		private readonly IRepository<User> _users;
		private readonly LoggedInUser _loggedInUser;
		public GetUsersWhoLikedPostQueryHandler(IRepository<User> users, LoggedInUser loggedInUser)
		{
			_users = users;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetUsersWhoLikedPost request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.LikedPosts)
				.Include(x => x.UserImages)
				.Where(x => x.LikedPosts.Select(x => x.PostId).Contains(request.PostId))
				.ToPage(request)
				.ToUserResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
