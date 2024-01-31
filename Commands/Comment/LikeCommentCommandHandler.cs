using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

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
            comment!.Like((int)request.LoggedInUserId!);
            return AppResponseDto.Success();
        }
    }
}
