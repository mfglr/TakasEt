using MediatR;

namespace Application.Dtos
{
    public class LikePostRequestDto : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public LikePostRequestDto(Guid postId)
        {
            PostId = postId;
        }
    }
}
