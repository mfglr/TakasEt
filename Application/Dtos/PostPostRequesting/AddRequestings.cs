using MediatR;

namespace Application.Dtos
{
	public class AddRequestings : IRequest<AppResponseDto>
	{
		public Guid RequestedId { get; private set; }
        public List<Guid> RequesterIds { get; private set; }

		public AddRequestings(Guid requestedId, List<Guid> requesterIds)
		{
			RequestedId = requestedId;
			RequesterIds = requesterIds;
		}
	}
}
