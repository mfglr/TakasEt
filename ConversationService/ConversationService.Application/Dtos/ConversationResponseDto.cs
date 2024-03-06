using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class ConversationResponseDto : BaseResponseDto<Guid>
    {
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
        public UserResponseDto? Receiver {  get; set; }
        public int CountOfMessagesUnviewed { get; set; }
        public DateTime DateTimeOfLastMessageReceived { get; set; }
        public MessageResponseDto? LastMessage { get; set; }
    }
}
