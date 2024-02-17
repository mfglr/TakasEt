using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;
using UserService.Application.Dtos;
using UserService.Infrastructure;

namespace UserService.Application.Commands
{
    internal class FollowCommandHandler : IRequestHandler<FollowDto, AppResponseDto>
    {

        private readonly AppDbContext _context;

        public FollowCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppResponseDto> Handle(FollowDto request, CancellationToken cancellationToken)
        {
            var user = await _context
                .Users
                .Include(
                    x => x
                        .UsersWhoBlockedTheEntity
                        .Where(x => x.BlockerId == request.FollowerId && !x.IsRemoved)
                )
                .Include(
                    x => x
                        .UsersTheEntityBlocked
                        .Where(x => x.BlockedId == request.FollowerId && !x.IsRemoved)
                )
                .Include(
                    x => x
                        .UsersWhoFollowedTheEntity
                        .Where(x => x.FollowerId == request.FollowerId && !x.IsRemoved)
                        .OrderByDescending(x => x.CreatedDate)
                        .FirstOrDefault()
                )
                .FirstOrDefaultAsync(x => x.Id == request.FollowingId && !x.IsRemoved);

            if (user == null) throw new AppException("User was not found!", HttpStatusCode.NotFound);

            user.Follow(request.FollowerId);

            await _context.SaveChangesAsync(cancellationToken);

            return AppResponseDto.Success();


        }
    }
}
