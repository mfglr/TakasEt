using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class UnlikeCommentCommandHandler : IRequestHandler<UnlikeComment, AppResponseDto>
    {
        private readonly IRepository<UserCommentLiking> _likes;

        public UnlikeCommentCommandHandler( IRepository<UserCommentLiking> likes)
        {
            _likes = likes;
        }

        public async Task<AppResponseDto> Handle(UnlikeComment request, CancellationToken cancellationToken)
        {
            var record = await _likes.DbSet.FirstOrDefaultAsync(
                x =>
                    x.UserId == request.LoggedInUserId &&
                    x.CommentId == request.CommentId,
                cancellationToken
            );
            if (record != null) _likes.DbSet.Remove(record);
            return AppResponseDto.Success();

        }
    }
}
