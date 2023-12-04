using MediatR;

namespace Application.Dtos
{
	public class LikePost : IRequest<AppResponseDto>
    {
        public int PostId { get; private set; }

        public LikePost(int postId)
        {
            PostId = postId;
        }
    }
}
