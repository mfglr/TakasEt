using ConversationService.Domain.UserConnectionAggregate;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MessageResponseDto : BaseResponseDto<string>
    {
        public Guid SenderId { get; set; }
        public UserConnectionResponseDto Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ViewedDate { get; set; }
        public IEnumerable<MessageImageResponseDto> Images { get; set; }
    }
}
