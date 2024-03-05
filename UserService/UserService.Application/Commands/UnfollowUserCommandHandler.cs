using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Net;
using UserService.Application.Dtos;
using UserService.Infrastructure;

namespace UserService.Application.Commands
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _blockingChecker;
        private readonly IUnitOfWork _unitOfWork;

        public UnfollowUserCommandHandler(AppDbContext context, IHttpContextAccessor contextAccessor, BlockingService blockingChecker, IUnitOfWork unitOfWork)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _blockingChecker = blockingChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(UnfollowDto request, CancellationToken cancellationToken)
        {

            await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(request.FollowingId.ToString());
            
            var logginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var user = await _context
                .Users
                .Include(x => x.UsersWhoFollowedTheEntity.Where(x => x.FollowerId == logginUserId))
                .FirstOrDefaultAsync(x => x.Id == request.FollowingId, cancellationToken);
            if(user == null)
                throw new AppException("User was not found!",HttpStatusCode.NotFound);
            user.Unfollow(logginUserId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new AppSuccessResponseDto();
        }
    }
}
