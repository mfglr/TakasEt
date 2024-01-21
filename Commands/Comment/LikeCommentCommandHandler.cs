using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class LikeCommentCommandHandler : IRequestHandler<LikeCommentDto, AppResponseDto>
    {
        private readonly IRepository<Comment> _comments;

        public LikeCommentCommandHandler(IRepository<Comment> comments)
        {
			_comments = comments;
        }

        public async Task<AppResponseDto> Handle(LikeCommentDto request, CancellationToken cancellationToken)
        {
            var comment = await _comments.DbSet.FindAsync(request.CommentId,cancellationToken);
            comment!.LikeComment(request.LoggedInUserId);
            return AppResponseDto.Success();
        }
    }
}
