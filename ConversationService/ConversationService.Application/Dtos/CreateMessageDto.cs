using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.SignalR.Dtos
{
    public class CreateMessageDto : IRequest<IAppResponseDto>
    {
        public string Id { get; set; }
        public Guid ReceiverId { get; set; }
        public string? Content { get; set; }
        public long SendDate { get; set; }
        public List<CreateMessageImageDto> Images { get; set; }
    }

    public class CreateMessageImageDto
    {
        public string BlobName {  get; set; }
        public string Extention { get; set; }
        public int Height { get;  set; }
        public int Width { get;  set; }
    }
}
