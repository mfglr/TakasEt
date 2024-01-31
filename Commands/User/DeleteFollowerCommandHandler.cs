using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DeleteFollowerCommandHandler : IRequestHandler<DeleteFollowerDto, AppResponseDto>
    {
        private readonly IRepository<User> _users;
        public DeleteFollowerCommandHandler(IRepository<User> users)
        {
			_users = users;
        }

        public async Task<AppResponseDto> Handle(DeleteFollowerDto request, CancellationToken cancellationToken)
        {
			var user = await _users
                .DbSet
                .FindAsync((int)request.LoggedInUserId!, cancellationToken);

			user!.DeleteFollower((int)request.FollowerId!);
			return AppResponseDto.Success();
		}
    }
}
