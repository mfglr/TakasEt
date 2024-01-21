using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class RemoveFollowerCommandHandler : IRequestHandler<RemoveFollowerDto, AppResponseDto>
    {
        private readonly IRepository<Following> _followings;

        public RemoveFollowerCommandHandler(IRepository<Following> followings)
        {
            _followings = followings;
        }

        public Task<AppResponseDto> Handle(RemoveFollowerDto request, CancellationToken cancellationToken)
        {
            _followings.DbSet.Remove(new Following(request.FollowerId, request.LoggedInUserId));
            return Task.Factory.StartNew(() => AppResponseDto.Success());
        }
    }
}
