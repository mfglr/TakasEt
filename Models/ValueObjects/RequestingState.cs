namespace Application.ValueObjects
{
	public class RequestingState
	{
		public int Status { get; private set; }

		public readonly static RequestingState Waiting = new RequestingState() { Status = 0 };
		public readonly static RequestingState Approved = new RequestingState() { Status = 1 };
		public readonly static RequestingState UnApproved = new RequestingState() { Status = 2 };
		public readonly static RequestingState Canceled = new RequestingState() { Status = 3 };

	}
}
