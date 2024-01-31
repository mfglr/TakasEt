using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DislikeCommentCommandHandler : IRequestHandler<DislikeCommentDto, AppResponseDto>
    {
		private readonly IRepository<Comment> _comments;

        public DislikeCommentCommandHandler(IRepository<Comment> comments)
        {
			_comments = comments;
        }

        public async Task<AppResponseDto> Handle(DislikeCommentDto request, CancellationToken cancellationToken)
        {
            var comment = await _comments
                .DbSet
                .FindAsync((int)request.CommentId!, cancellationToken);
            comment!.Dislike((int)request.LoggedInUserId!);
            return AppResponseDto.Success();
        }
    }
}
