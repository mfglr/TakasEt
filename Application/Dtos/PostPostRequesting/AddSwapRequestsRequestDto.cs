using MediatR;

namespace Application.Dtos
{
	public class AddSwapRequestsRequestDto : IRequest<AppResponseDto>
	{
		public Guid RequestedId { get; private set; }
        public List<Guid> RequesterIds { get; private set; }

		public AddSwapRequestsRequestDto(Guid requestedId, List<Guid> requesterIds)
		{
			RequestedId = requestedId;
			RequesterIds = requesterIds;
		}
	}
}
