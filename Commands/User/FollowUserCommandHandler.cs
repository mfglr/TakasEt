using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserDto, AppResponseDto>
    {


        private readonly IRepository<Following> _followeds;

        public FollowUserCommandHandler(IRepository<Following> followeds)
        {
            _followeds = followeds;
        }

        public async Task<AppResponseDto> Handle(FollowUserDto request, CancellationToken cancellationToken)
        {

            await _followeds
                .DbSet
                .AddAsync(
                   new Following(request.LoggedInUserId, request.FollowingId),
                   cancellationToken
                );
            return AppResponseDto.Success();
        }
    }
}
