using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class RemoveCommentHandler : IRequestHandler<RemoveCommentDto, AppResponseDto>
    {
        private readonly IRepository<Comment> _comments;

        public RemoveCommentHandler(IRepository<Comment> comments)
        {
            _comments = comments;
        }

        public async Task<AppResponseDto> Handle(RemoveCommentDto request, CancellationToken cancellationToken)
        {
            //var comment = await _comments.DbSet
            //	.IncludeChildrenByRecursive(Comment.Depth)
            //	.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            //if (comment == null) throw new CommentNotFoundException();
            //_comments.DbSet.RemoveRecursive(comment);
            return AppResponseDto.Success();
        }
    }
}
