using MediatR;

namespace Models.Dtos.Conversation
{
	public class AddUserSignalRStateDto : IRequest<NoContentResponseDto>
	{
		public int? UserId { get; private set; }
		public string? ConnectionId { get; private set; }

        public AddUserSignalRStateDto(int? userId, string? connectionId)
        {
            UserId = userId;
            ConnectionId = connectionId;
        }
    }
}
