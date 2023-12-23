using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetFollowedsQueryHandler : IRequestHandler<GetFolloweds, AppResponseDto>
	{
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<User> _users;

		public GetFollowedsQueryHandler(LoggedInUser loggedInUser, IRepository<User> users)
		{
			_loggedInUser = loggedInUser;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetFolloweds request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.UserImages)
				.Where(user => user.Followers.Any(follower => follower.FollowerId == _loggedInUser.UserId))
				.ToPage(request)
				.ToUserResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
