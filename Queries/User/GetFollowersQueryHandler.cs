using Models.Extentions;
using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetFollowersQueryHandler : IRequestHandler<GetFollowersDto, AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetFollowersQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetFollowersDto request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.IncludeUser()
				.Where(user => user.Followings.Any(x => x.FollowingId == request.LoggedInUserId))
				.ToPage(request)
				.ToUserResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
