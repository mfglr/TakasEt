using MediatR;

namespace Models.Dtos
{
	public class SetMessageHubStateDto : IRequest<AppResponseDto>
	{
		public int? UserId { get; private set; }
		public string? ConnectionId { get; private set; }

		public SetMessageHubStateDto(int? userId, string? connectionId)
		{
			UserId = userId;
			ConnectionId = connectionId;
		}
	}
}
