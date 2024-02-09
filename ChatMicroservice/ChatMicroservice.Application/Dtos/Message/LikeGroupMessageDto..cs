using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
    public class LikeGroupMessageDto : IRequest<AppResponseDto>
    {
        public int LikerId { get; set; }
        public int GroupId { get; set; }
        public int MessageId { get; set; }
    }
}
