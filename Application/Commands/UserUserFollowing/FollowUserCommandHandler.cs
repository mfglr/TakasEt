using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUser, AppResponseDto>
    {


        private readonly IRepository<UserUserFollowing> _followeds;
        private readonly LoggedInUser _loggedInUser;

		public FollowUserCommandHandler(IRepository<UserUserFollowing> followeds, LoggedInUser loggedInUser)
		{
			_followeds = followeds;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(FollowUser request, CancellationToken cancellationToken)
        {
            var record = await _followeds.DbSet.AnyAsync(
                x => x.FollowerId == _loggedInUser.UserId && x.FollowedId == request.FollowedId,
                cancellationToken
            );
            if (!record)
                await _followeds.DbSet.AddAsync(
                    new UserUserFollowing(_loggedInUser.UserId, request.FollowedId),
                    cancellationToken
                );
            return AppResponseDto.Success();
        }
    }
}
