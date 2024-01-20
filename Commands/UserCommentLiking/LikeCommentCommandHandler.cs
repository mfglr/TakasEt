using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class LikeCommentCommandHandler : IRequestHandler<LikeComment, AppResponseDto>
    {
        private readonly IRepository<UserCommentLiking> _likes;

        public LikeCommentCommandHandler(IRepository<UserCommentLiking> likes)
        {
            _likes = likes;
        }

        public async Task<AppResponseDto> Handle(LikeComment request, CancellationToken cancellationToken)
        {
            var anyRecord = await _likes.DbSet.AnyAsync(
                x =>
                    x.UserId == request.LoggedInUserId &&
                    x.CommentId == request.CommentId,
                cancellationToken
            );
            if (!anyRecord)
                await _likes.DbSet.AddAsync(
                    new UserCommentLiking(request.LoggedInUserId, request.CommentId),
                    cancellationToken
                );
            return AppResponseDto.Success();

        }
    }
}
