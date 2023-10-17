using MediatR;

namespace Application.Dtos
{
    public class IsCommentLiked : IRequest<AppResponseDto>
    {
        public Guid CommentId { get; private set; }

        public IsCommentLiked(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}
