using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using System.Net;
using UserService.Application.Dtos;
using UserService.Infrastructure;

namespace UserService.Application.Commands
{
    public class FollowCommandHandler : IRequestHandler<FollowDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _blockingCheckerService;

        public FollowCommandHandler(AppDbContext context, IHttpContextAccessor contextAccessor, BlockingService blockingCheckerService)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _blockingCheckerService = blockingCheckerService;
        }

        public async Task<IAppResponseDto> Handle(FollowDto request, CancellationToken cancellationToken)
        {
            await _blockingCheckerService.ThrowExceptionIfBlockerOfBlockedAsync(request.UserId.ToString());

            var logginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var user = await _context
                .Users
                .Include(
                    x => x.UsersWhoFollowedTheEntity.FirstOrDefault(
                        x => x.FollowerId == logginUserId && !x.IsRemoved
                    )
                )
                .Include(
                    x => x.UsersWhoWantToFollowTheUser.Where(x => x.RequesterId == logginUserId)
                )
                .FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsRemoved);
            if (user == null)
                throw new AppException("User was not found!", HttpStatusCode.NotFound);
            user.Follow(logginUserId);

            await _context.SaveChangesAsync(cancellationToken);

            return new AppSuccessResponseDto();
        }
    }
}
