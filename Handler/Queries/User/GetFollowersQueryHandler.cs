using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetFollowersQueryHandler : IRequestHandler<GetFollowers, AppResponseDto>
	{
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<User> _users;

		public GetFollowersQueryHandler(LoggedInUser loggedInUser, IRepository<User> users)
		{
			_loggedInUser = loggedInUser;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetFollowers request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.ProfileImages)
				.Where(user => user.Followeds.Any(followed => followed.FollowedId == _loggedInUser.UserId))
				.ToPage(request)
				.ToUserResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
