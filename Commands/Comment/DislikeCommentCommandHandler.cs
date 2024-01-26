using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DislikeCommentCommandHandler : IRequestHandler<DislikeCommentDto, AppResponseDto>
    {
		private readonly IReadRepository<Comment> _comments;

        public DislikeCommentCommandHandler(IReadRepository<Comment> comments)
        {
			_comments = comments;
        }

        public async Task<AppResponseDto> Handle(DislikeCommentDto request, CancellationToken cancellationToken)
        {
            var comment = await _comments.GetByIdAsync((int)request.CommentId!, cancellationToken);
            comment!.Dislike((int)request.LoggedInUserId!);
            return AppResponseDto.Success();
        }
    }
}
