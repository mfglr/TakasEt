using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserDto, AppResponseDto>
    {


        private readonly IReadRepository<User> _users;

        public FollowUserCommandHandler(IReadRepository<User> users)
        {
			_users = users;
        }

        public async Task<AppResponseDto> Handle(FollowUserDto request, CancellationToken cancellationToken)
        {

            var user = await _users.GetByIdAsync(request.FollowingId, cancellationToken);
            user!.Follow(request.LoggedInUserId);
            return AppResponseDto.Success();
        }
    }
}
