using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserDto, AppResponseDto>
    {


        private readonly IRepository<User> _users;

        public FollowUserCommandHandler(IRepository<User> users)
        {
			_users = users;
        }

        public async Task<AppResponseDto> Handle(FollowUserDto request, CancellationToken cancellationToken)
        {

            var user = await _users
                .DbSet
                .FindAsync(request.FollowingId, cancellationToken);
            user!.Follow(request.LoggedInUserId);
            return AppResponseDto.Success();
        }
    }
}
