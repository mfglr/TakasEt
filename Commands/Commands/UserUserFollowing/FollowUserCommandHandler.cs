using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Handler.Commands
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

			await _followeds
				.DbSet
				.AddAsync(
				   new UserUserFollowing(_loggedInUser.UserId, request.FollowedId),
				   cancellationToken
				);
			return AppResponseDto.Success();
        }
    }
}
