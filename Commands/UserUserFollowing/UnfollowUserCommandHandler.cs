using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUser, AppResponseDto>
    {

        private readonly IRepository<UserUserFollowing> _followings;
        private readonly LoggedInUser _user;

        public UnfollowUserCommandHandler(IRepository<UserUserFollowing> followings, LoggedInUser user)
        {
            _followings = followings;
            _user = user;
        }

        public async Task<AppResponseDto> Handle(UnfollowUser request, CancellationToken cancellationToken)
        {
            var record = await _followings.DbSet.SingleOrDefaultAsync(x => x.FollowerId == _user.UserId && x.FollowedId == request.FollowedId, cancellationToken);
            if (record != null) _followings.DbSet.Remove(record);
            return AppResponseDto.Success();
        }
    }
}
