using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetFollowedsQueryHandler : IRequestHandler<GetFollowedsDto, AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetFollowedsQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetFollowedsDto request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.IncludeUser()
				.Where(user => user.Followers.Any(follower => follower.FollowerId == request.LoggedInUserId))
				.ToPage(request)
				.ToUserResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
