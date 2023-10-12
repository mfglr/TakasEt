using MediatR;

namespace Application.Dtos
{
    public class LikePost : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public LikePost(Guid postId)
        {
            PostId = postId;
        }
    }
}
