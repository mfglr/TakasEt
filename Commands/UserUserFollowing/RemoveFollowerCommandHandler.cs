using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class RemoveFollowerCommandHandler : IRequestHandler<RemoveFollowerDto, AppResponseDto>
    {
        private readonly IRepository<UserUserFollowing> _followings;

        public RemoveFollowerCommandHandler(IRepository<UserUserFollowing> followings)
        {
            _followings = followings;
        }

        public Task<AppResponseDto> Handle(RemoveFollowerDto request, CancellationToken cancellationToken)
        {
            _followings.DbSet.Remove(new UserUserFollowing(request.FollowerId, request.LoggedInUserId));
            return Task.Factory.StartNew(() => AppResponseDto.Success());
        }
    }
}
