using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MessageResponseDto : BaseResponseDto<string>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid ConversationId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public IEnumerable<MessageImageResponseDto> Images { get; set; }
    }
}
