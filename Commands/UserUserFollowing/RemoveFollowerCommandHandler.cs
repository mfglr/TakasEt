using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class RemoveFollowerCommandHandler : IRequestHandler<RemoveFollower, AppResponseDto>
    {
        private readonly LoggedInUser _loggedInUser;
        private readonly IRepository<UserUserFollowing> _followings;

        public RemoveFollowerCommandHandler(LoggedInUser loggedInUser, IRepository<UserUserFollowing> followings)
        {
            _loggedInUser = loggedInUser;
            _followings = followings;
        }

        public Task<AppResponseDto> Handle(RemoveFollower request, CancellationToken cancellationToken)
        {
            _followings.DbSet.Remove(new UserUserFollowing(request.FollowerId, _loggedInUser.UserId));
            return Task.Factory.StartNew(() => AppResponseDto.Success());
        }
    }
}
