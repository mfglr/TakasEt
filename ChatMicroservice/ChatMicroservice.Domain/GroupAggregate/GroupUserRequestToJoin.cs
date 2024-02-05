using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUserRequestToJoin : Entity
	{
		public Guid UserId { get; private set; }
		public Guid? IdOfUserApprovingOrCancellingRequest { get; private set; }
		public GroupUserRequestToJoin(Guid userId) => UserId = userId;

		public StateOfGroupJoinRequest State { get; private set; }
		public void MarkAsPendingApproval() => State = StateOfGroupJoinRequest.PendingApproval;
		public void MarkAsApproved(Guid approverId) {
			State = StateOfGroupJoinRequest.Approved;
			IdOfUserApprovingOrCancellingRequest = approverId;
		}
		public void MarkAsCancelled(Guid cancellerId)
		{
			State = StateOfGroupJoinRequest.Cancelled;
			IdOfUserApprovingOrCancellingRequest = cancellerId;
		}
	}
}
