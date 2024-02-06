using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUserRequestToJoin : Entity
	{
		public int UserId { get; private set; }
		public int? IdOfUserApprovingOrCancellingRequest { get; private set; }
		public GroupUserRequestToJoin(int userId) => UserId = userId;

		public StateOfGroupJoinRequest State { get; private set; }
		public void MarkAsPendingApproval() => State = StateOfGroupJoinRequest.PendingApproval;
		public void MarkAsApproved(int approverId) {
			State = StateOfGroupJoinRequest.Approved;
			IdOfUserApprovingOrCancellingRequest = approverId;
		}
		public void MarkAsCancelled(int cancellerId)
		{
			State = StateOfGroupJoinRequest.Cancelled;
			IdOfUserApprovingOrCancellingRequest = cancellerId;
		}
	}
}
