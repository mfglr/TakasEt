using MediatR;

namespace Application.Dtos
{
    public class UnLikePost : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }
        public UnLikePost(Guid postId)
        {
            PostId = postId;
        }
    }
}
