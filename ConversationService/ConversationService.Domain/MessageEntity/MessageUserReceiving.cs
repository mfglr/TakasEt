namespace ConversationService.Domain.MessageEntity
{
	public class MessageUserReceiving
	{
        public Guid UserId { get; private set; }

        public MessageUserReceiving(Guid userId)
		{
			UserId = userId;
		}

	}
}
