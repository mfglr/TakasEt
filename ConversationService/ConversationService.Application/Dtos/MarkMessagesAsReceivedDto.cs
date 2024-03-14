using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MessageItem
    {
        public string Id { get; set; }
        public long ReceivedDate { get; set; }
    }

    public class MarkMessagesAsReceivedDto : IRequest<IAppResponseDto>
    {
        public List<MessageItem> MessageItems { get; set; }
    }
}
