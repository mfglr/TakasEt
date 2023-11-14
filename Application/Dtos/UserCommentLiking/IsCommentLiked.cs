using MediatR;

namespace Application.Dtos
{
    public class IsCommentLiked : IRequest<AppResponseDto>
    {
        public int CommentId { get; private set; }

        public IsCommentLiked(int commentId)
        {
            CommentId = commentId;
        }
    }
}
