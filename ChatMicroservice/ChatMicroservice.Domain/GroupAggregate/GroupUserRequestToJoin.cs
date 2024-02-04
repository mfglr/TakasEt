using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUserRequestToJoin : Entity
	{
		public Guid UserId { get; private set; }
        public GroupUserRequestToJoin(Guid userId) => UserId = userId;

		public StateOfGroupJoinRequest State { get; private set; }
		public void MarkAsPendingApproval() => State = StateOfGroupJoinRequest.PendingApproval;
		public void MarkAsConfirmed() => State = StateOfGroupJoinRequest.Confirmed;
		public void MarkAsCancelled() => State = StateOfGroupJoinRequest.Cancelled;
	}
}
