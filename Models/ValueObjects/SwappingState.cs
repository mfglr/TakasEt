namespace Models.ValueObjects
{
	public class SwappingState
	{
		public bool Status { get; private set; }

		public static SwappingState Approved = new SwappingState() { Status = false };
		public static SwappingState Canceled = new SwappingState() { Status = true };
	}
}
