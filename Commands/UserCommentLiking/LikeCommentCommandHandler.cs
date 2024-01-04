using Application.Configurations;
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
        private readonly LoggedInUser _loggedInUser;

        public LikeCommentCommandHandler(IRepository<UserCommentLiking> likes, LoggedInUser loggedInUser)
        {
            _likes = likes;
            _loggedInUser = loggedInUser;
        }

        public async Task<AppResponseDto> Handle(LikeComment request, CancellationToken cancellationToken)
        {
            var anyRecord = await _likes.DbSet.AnyAsync(
                x =>
                    x.UserId == _loggedInUser.UserId &&
                    x.CommentId == request.CommentId,
                cancellationToken
            );
            if (!anyRecord)
                await _likes.DbSet.AddAsync(
                    new UserCommentLiking(_loggedInUser.UserId, request.CommentId),
                    cancellationToken
                );
            return AppResponseDto.Success();

        }
    }
}
