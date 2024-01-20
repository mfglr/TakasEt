using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class DislikePostCommandHandler : IRequestHandler<DislikePostDto, AppResponseDto>
    {
        private readonly IRepository<UserPostLiking> _likes;

        public DislikePostCommandHandler(IRepository<UserPostLiking> likes)
        {
            _likes = likes;
        }

        public async Task<AppResponseDto> Handle(DislikePostDto request, CancellationToken cancellationToken)
        {
            var record = await _likes.DbSet.SingleOrDefaultAsync(x => x.UserId == request.LoggedInUserId && x.PostId == request.PostId, cancellationToken);
            if (record != null) _likes.DbSet.Remove(record);
            return AppResponseDto.Success();
        }
    }
}
