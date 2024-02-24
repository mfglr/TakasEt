using SharedLibrary.Entities;
using SharedLibrary.ValueObjects;

namespace ConversationService.Domain.ConversationAggregate
{
    public class MessageImage : Image
    {
        public MessageImage() { }

        public MessageImage(string blobName, string extention, Dimension dimension) : base(ContainerName.MessageImages, blobName, extention, dimension)
        {
        }
    }
}
