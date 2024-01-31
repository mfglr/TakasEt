using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUserDto, AppResponseDto>
    {

        private readonly IRepository<Following> _followings;

        public UnfollowUserCommandHandler(IRepository<Following> followings)
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
