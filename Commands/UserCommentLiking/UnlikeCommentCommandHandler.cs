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
        private readonly LoggedInUser _loggedInUser;
        private readonly IRepository<UserCommentLiking> _likes;

        public UnlikeCommentCommandHandler(LoggedInUser loggedInUser, IRepository<UserCommentLiking> likes)
        {
            _loggedInUser = loggedInUser;
            _likes = likes;
        }

        public async Task<AppResponseDto> Handle(UnlikeComment request, CancellationToken cancellationToken)
        {
            var record = await _likes.DbSet.FirstOrDefaultAsync(
                x =>
                    x.UserId == _loggedInUser.UserId &&
                    x.CommentId == request.CommentId,
                cancellationToken
            );
            if (record != null) _likes.DbSet.Remove(record);
            return AppResponseDto.Success();

        }
    }
}
