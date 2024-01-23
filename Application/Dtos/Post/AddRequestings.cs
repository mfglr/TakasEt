using MediatR;

namespace Application.Dtos
{
	public class AddRequestings : IRequest<AppResponseDto>
	{
		public int RequestedId { get; private set; }
        public List<int> RequesterIds { get; private set; }
		public int LoggedInUserId {  get; private set; }

		public AddRequestings(int requestedId, List<int> requesterIds, int loggedInUserId)
		{
			RequestedId = requestedId;
			RequesterIds = requesterIds;
			LoggedInUserId = loggedInUserId;
		}
	}
}
