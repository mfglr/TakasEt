using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class SetMessageHubStateCommandHandler : IRequestHandler<SetMessageHubStateDto, AppResponseDto>
	{

		private readonly IRepository<User> _users;

		public SetMessageHubStateCommandHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(SetMessageHubStateDto request, CancellationToken cancellationToken)
		{
			var user = await _users
				.DbSet
				.Include(x => x.MessageHubState)
				.FirstOrDefaultAsync(x => x.Id == request.UserId);
			user!.SetMessageHubState(request.ConnectionId!);
			return AppResponseDto.Success();
		}
	}
}
