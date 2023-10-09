using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    public class LikePostCommadHandler : IRequestHandler<LikePostRequestDto, AppResponseDto>
    {
        private readonly IRepository<UserPostLiking> _likes;
        private readonly LoggedInUser _user;
        public LikePostCommadHandler(IRepository<UserPostLiking> likes, LoggedInUser user)
        {
            _likes = likes;
            _user = user;
        }
        public async Task<AppResponseDto> Handle(LikePostRequestDto request, CancellationToken cancellationToken)
        {
            if (!await _likes.DbSet.AnyAsync(x => x.UserId == _user.UserId && x.PostId == request.PostId, cancellationToken))
                await _likes.DbSet.AddAsync(new UserPostLiking(_user.UserId, request.PostId), cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
