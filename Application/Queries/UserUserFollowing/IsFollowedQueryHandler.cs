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
<<<<<<< HEAD
			var isFollowed = await _followings
=======
			var data = await _followings
>>>>>>> 09da29054d6471dde54a0de1d45413d2928e3635
				.DbSet
				.AnyAsync(
					x =>
						x.FollowerId == _loggedInUser.UserId &&
						x.FollowedId == request.UserId,
					cancellationToken
				);
<<<<<<< HEAD
			return AppResponseDto.Success(isFollowed);
=======
			return AppResponseDto.Success(data);
>>>>>>> 09da29054d6471dde54a0de1d45413d2928e3635
		}
	}
}
