using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class RemoveCommentHandler : IRequestHandler<RemoveComment, AppResponseDto>
    {
        private readonly IRepository<Comment> _comments;

        public RemoveCommentHandler(IRepository<Comment> comments)
        {
            _comments = comments;
        }

        public async Task<AppResponseDto> Handle(RemoveComment request, CancellationToken cancellationToken)
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
