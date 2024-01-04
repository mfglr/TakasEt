using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class UnLikePostCommandHandler : IRequestHandler<UnLikePost, AppResponseDto>
    {
        private readonly IRepository<UserPostLiking> _likes;
        private readonly LoggedInUser _user;
        public UnLikePostCommandHandler(IRepository<UserPostLiking> likes, LoggedInUser user)
        {
            _likes = likes;
            _user = user;
        }

        public async Task<AppResponseDto> Handle(UnLikePost request, CancellationToken cancellationToken)
        {
            var record = await _likes.DbSet.SingleOrDefaultAsync(x => x.UserId == _user.UserId && x.PostId == request.PostId, cancellationToken);
            if (record != null) _likes.DbSet.Remove(record);
            return AppResponseDto.Success();
        }
    }
}
