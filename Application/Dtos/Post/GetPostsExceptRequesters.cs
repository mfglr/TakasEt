using MediatR;

namespace Application.Dtos.Post
{
    public class GetPostsExceptRequesters : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public GetPostsExceptRequesters(Guid postId) { PostId = postId; }
    }
}
