using SharedLibrary.Entities;
using SharedLibrary.ValueObjects;

namespace ConversationService.Domain.MessageAggregate
{
    public class MessageImage : Image<Guid>
    {
        public MessageImage() { }

        public MessageImage(string blobName, string extention, int height, int width) : base(ContainerName.CreateContainerName(ContainerName.MessageImages), blobName, extention, height, width)
        {
        }
    }
}
