namespace Application.ValueObjects
{
	public class RequestingStatus
	{
		public int Status { get; private set; }

		public readonly static RequestingStatus Waiting = new RequestingStatus() { Status = 0 };
		public readonly static RequestingStatus Approved = new RequestingStatus() { Status = 1 };
		public readonly static RequestingStatus UnApproved = new RequestingStatus() { Status = 2 };
		public readonly static RequestingStatus Canceled = new RequestingStatus() { Status = 3 };

	}
}
