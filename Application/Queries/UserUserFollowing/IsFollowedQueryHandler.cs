using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class IsFollowedQueryHandler : IRequestHandler<IsFollowed, AppResponseDto>
	{
		private readonly IRepository<UserUserFollowing> _followings;
		private readonly LoggedInUser _loggedInUser;

		public IsFollowedQueryHandler(IRepository<UserUserFollowing> followings, LoggedInUser loggedInUser)
		{
			_followings = followings;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(IsFollowed request, CancellationToken cancellationToken)
		{
			var data = await _followings
				.DbSet
				.AnyAsync(
					x =>
						x.FollowerId == _loggedInUser.UserId &&
						x.FollowedId == request.UserId,
					cancellationToken
				);
			return AppResponseDto.Success(data);
		}
	}
}
