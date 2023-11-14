using MediatR;

namespace Application.Dtos
{
    public class UnLikePost : IRequest<AppResponseDto>
    {
        public int PostId { get; private set; }
        public UnLikePost(int postId)
        {
            PostId = postId;
        }
    }
}
