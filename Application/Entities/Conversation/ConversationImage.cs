using Application.ValueObjects;

namespace Application.Entities
{
	public class ConversationImage : Image
	{
		public bool IsActive { get; private set; }
		public int ConversationId { get; private set; }

		public Conversation Conversation { get; }

		public ConversationImage() {}

        public ConversationImage(string blobName, string extention,Dimension dimension) : base(ContainerName.ConversationImage,blobName,extention,dimension) { }

		public void Activate() { IsActive = true; }
		public void Deactivate() { IsActive = false; }
	}
}
