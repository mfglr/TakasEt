using MediatR;

namespace Application.Dtos
{
	public class LikePostDto : IRequest<AppResponseDto>
    {
        public int? LoggedInUserId { get; private set; }
        public int? PostId { get; private set; }

        public LikePostDto(int? loggedInUserId, int? postId)
        {
            LoggedInUserId = loggedInUserId;
            PostId = postId;
        }
    }
}
