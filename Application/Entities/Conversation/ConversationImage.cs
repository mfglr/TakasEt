namespace Application.Entities
{
	public class ConversationImage : Entity
	{
		public bool IsActive { get; private set; }
		public int ConversationId { get; private set; }
		public string BlobName { get; private set; }
		public string Extention { get; private set; }
		public string ContainerName { get; private set; }

		public Conversation Conversation { get; }

		public ConversationImage(int conversationId, string blobName, string extention)
		{
			ConversationId = conversationId;
			BlobName = blobName;
			Extention = extention;
			ContainerName = ValueObjects.ContainerName.ConversationImage.Value;
		}

		public void Activate()
		{
			IsActive = true;
		}

		public void Deactivate()
		{
			IsActive = false;
		}
	}
}
