using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class LikePostCommadHandler : IRequestHandler<LikePostDto, AppResponseDto>
    {
        private readonly IRepository<UserPostLiking> _likes;
        public LikePostCommadHandler(IRepository<UserPostLiking> likes)
        {
            _likes = likes;
        }
        public async Task<AppResponseDto> Handle(LikePostDto request, CancellationToken cancellationToken)
        {
            if (!await _likes.DbSet.AnyAsync(x => x.UserId == request.LoggedInUserId && x.PostId == request.PostId, cancellationToken))
                await _likes.DbSet.AddAsync(new UserPostLiking(request.LoggedInUserId, request.PostId), cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
