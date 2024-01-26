using MediatR;

namespace Models.Dtos
{
	public class DislikePostDto : IRequest<AppResponseDto>
    {
        public int PostId { get; private set; }
        public int LoggedInUserId { get; private set; }

        public DislikePostDto(int postId,int loggedInUserId)
        {
            PostId = postId;
            LoggedInUserId = loggedInUserId;
        }
    }
}
