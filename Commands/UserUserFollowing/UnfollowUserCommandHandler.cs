using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUserDto, AppResponseDto>
    {

        private readonly IRepository<UserUserFollowing> _followings;

        public UnfollowUserCommandHandler(IRepository<UserUserFollowing> followings)
        {
            _followings = followings;
        }

        public async Task<AppResponseDto> Handle(UnfollowUserDto request, CancellationToken cancellationToken)
        {
            var record = await _followings.DbSet.SingleOrDefaultAsync(x => x.FollowerId == request.LoggedInUserId && x.FollowingId == request.FollowingId, cancellationToken);
            if (record != null) _followings.DbSet.Remove(record);
            return AppResponseDto.Success();
        }
    }
}
