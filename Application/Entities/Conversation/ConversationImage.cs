using Application.ValueObjects;

namespace Application.Entities
{
	public class ConversationImage : Entity, IImage
	{
		public bool IsActive { get; private set; }
		public int ConversationId { get; private set; }
		public string BlobName { get; private set; }
		public string Extention { get; private set; }
		public Dimension Dimension { get; private set; }
		public float AspectRatio { get; private set; }
		public ContainerName ContainerName { get; private set; }

		public Conversation Conversation { get; }


		public ConversationImage() {}

        public ConversationImage(int conversationId, string blobName, string extention,Dimension dimension)
		{
			ConversationId = conversationId;
			BlobName = blobName;
			Extention = extention;
			ContainerName = ContainerName.ConversationImage;
			Dimension = dimension;
			AspectRatio = dimension.CalculateAspectRatio();
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
