using SharedLibrary.ValueObjects;

namespace ConversationService.Domain.MessageEntity
{
	public class MessageState : ValueObject
	{
		public int Status { get; private set; }

		public readonly static MessageState Saved = new () { Status = 0 };
		public readonly static MessageState Received = new() { Status = 1 };
		public readonly static MessageState Viewed = new() { Status = 2 };

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Status;
		}
	}
}
