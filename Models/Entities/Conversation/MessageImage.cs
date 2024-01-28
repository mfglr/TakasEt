using Models.ValueObjects;

namespace Models.Entities
{
	public class MessageImage : Image
	{
		public int MessageId { get; }
		public Message Message { get; }

		public MessageImage() { }

		public MessageImage(string blobName, string extention, Dimension dimension) : base(ContainerName.MessageImage, blobName, extention, dimension)
		{
		}
	}
}
