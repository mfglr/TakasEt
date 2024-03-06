using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class ConversationResponseDto : BaseResponseDto<Guid>
    {
        public Guid ReceiverId { get; set; }
        public UserResponseDto? Receiver {  get; set; }
        public int CountOfMessagesUnviewed { get; set; }
        public DateTime DateTimeOfLastMessage { get; set; }
        public MessageResponseDto? LastMessage { get; set; }
    }
}
