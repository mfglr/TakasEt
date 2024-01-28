namespace Models.ValueObjects
{
	public class MessageState
	{
		public int Status { get; private set; }

		public readonly static MessageState Saved = new MessageState { Status = 0 };
		public readonly static MessageState Arrived = new MessageState { Status = 1 };
		public readonly static MessageState Viewed = new MessageState { Status = 2 };
	}
}
