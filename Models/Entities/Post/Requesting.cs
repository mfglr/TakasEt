using Application.ValueObjects;
using Models.DomainEventModels;

namespace Models.Entities
{
    public class Requesting : CrossEntity
    {
        public int RequesterId { get; private set; }
        public int RequestedId { get; private set; }
        public RequestingState Status { get; private set; }

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
            Status = RequestingState.Waiting;
        }

        public void ApproveRequest()
        {
            Status = RequestingState.Approved;
            AddDomainEvent(new RequestingDomainEvent(this));
        }
        public void CancelRequest()
        {
            Status = RequestingState.Canceled;
        }
        public void UnApproveRequest()
        {
            Status = RequestingState.UnApproved;
        }


    }
}
