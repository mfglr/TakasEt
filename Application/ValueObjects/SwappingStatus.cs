namespace Application.ValueObjects
{
	public class SwappingStatus
	{
		public bool Status { get; private set; }

		public static SwappingStatus Approved = new SwappingStatus() { Status = false };
		public static SwappingStatus Canceled = new SwappingStatus() { Status = true };
	}
}
