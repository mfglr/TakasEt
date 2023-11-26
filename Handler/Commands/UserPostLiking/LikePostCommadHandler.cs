using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Commands
{
    public class LikePostCommadHandler : IRequestHandler<LikePost, AppResponseDto>
    {
        private readonly IRepository<UserPostLiking> _likes;
        private readonly LoggedInUser _loggedInUser;
        public LikePostCommadHandler(IRepository<UserPostLiking> likes, LoggedInUser loggedInUser)
        {
            _likes = likes;
			_loggedInUser = loggedInUser;
        }
        public async Task<AppResponseDto> Handle(LikePost request, CancellationToken cancellationToken)
        {
            if (!await _likes.DbSet.AnyAsync(x => x.UserId == _loggedInUser.UserId && x.PostId == request.PostId, cancellationToken))
                await _likes.DbSet.AddAsync(new UserPostLiking(_loggedInUser.UserId, request.PostId), cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
