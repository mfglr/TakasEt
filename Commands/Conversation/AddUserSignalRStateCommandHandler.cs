using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Dtos.Conversation;

namespace Commands.Conversation
{
	public class AddUserSignalRStateCommandHandler : IRequestHandler<AddUserSignalRStateDto,NoContentResponseDto>
	{
		private readonly IUserReadRepository _users;

		public AddUserSignalRStateCommandHandler(IUserReadRepository users)
		{
			_users = users;
		}

		public async Task<NoContentResponseDto> Handle(AddUserSignalRStateDto request, CancellationToken cancellationToken)
		{
			var user = await _users.GetUserWithSignalRStateAsync((int)request.UserId!, cancellationToken);
			user.AddUserSignalRState(request.ConnectionId!);
			return new NoContentResponseDto();
		}
	}
}
