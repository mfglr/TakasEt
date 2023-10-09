using MediatR;

namespace Application.Dtos
{
    public class UnlikePostRequestDto : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }
        public UnlikePostRequestDto(Guid postId)
        {
            PostId = postId;
        }
    }
}
