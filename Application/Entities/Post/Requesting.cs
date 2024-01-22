using Application.DomainEventModels;
using Application.ValueObjects;

namespace Application.Entities
{
	public class Requesting : CrossEntity
	{
		public int RequesterId { get; private set; }
		public int RequestedId { get; private set; }
		public RequestingStatus Status { get; private set; }

		public Post Requester { get; }
		public Post Requested { get; }

		public override int[] GetKey()
		{
			return new[] { RequesterId, RequestedId };
		}

		public Requesting(int requesterId, int requestedId)
		{
			RequesterId = requesterId;
			RequestedId = requestedId;
			Status = RequestingStatus.Waiting;
		}

		public void ApproveRequest()
		{
			Status = RequestingStatus.Approved;
			AddDomainEvent(new RequestingDomainEvent(this));
		}
		public void CancelRequest()
		{
			Status = RequestingStatus.Canceled;
		}
		public void UnApproveRequest()
		{
			Status = RequestingStatus.UnApproved;
		}

		
	}
}
