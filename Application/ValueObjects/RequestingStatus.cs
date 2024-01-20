namespace Application.ValueObjects
{
	public class RequestingStatus
	{
		public int Status { get; private set; }

		public static RequestingStatus Waiting = new RequestingStatus() { Status = 0 };
		public static RequestingStatus Approved = new RequestingStatus() { Status = 1 };
		public static RequestingStatus UnApproved = new RequestingStatus() { Status = 2 };
		public static RequestingStatus Canceled = new RequestingStatus() { Status = 3 };

	}
}
