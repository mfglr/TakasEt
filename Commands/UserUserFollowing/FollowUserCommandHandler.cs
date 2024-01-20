using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserDto, AppResponseDto>
    {


        private readonly IRepository<UserUserFollowing> _followeds;

        public FollowUserCommandHandler(IRepository<UserUserFollowing> followeds)
        {
            _followeds = followeds;
        }

        public async Task<AppResponseDto> Handle(FollowUserDto request, CancellationToken cancellationToken)
        {

            await _followeds
                .DbSet
                .AddAsync(
                   new UserUserFollowing(request.LoggedInUserId, request.FollowingId),
                   cancellationToken
                );
            return AppResponseDto.Success();
        }
    }
}
