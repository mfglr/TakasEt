using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class StateOfGroupJoinRequest : ValueObject
	{
		public int Status { get; private set; }

		public readonly static StateOfGroupJoinRequest PendingApproval = new () { Status = 0 };
		public readonly static StateOfGroupJoinRequest Confirmed = new () { Status = 1 };
		public readonly static StateOfGroupJoinRequest Cancelled = new () { Status = 2 };

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Status;
		}
	}
}
