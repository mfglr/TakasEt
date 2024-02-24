using AuthService.Application.Dtos;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace AuthService.Application.Queries
{
    public class IsBlockedQueryHandler : IRequestHandler<IsBlockedDto, IAppResponseDto>
    {

        private readonly UserManager<UserAccount> _userManager;
        private readonly IHttpContextAccessor _contextAccestor;

        public IsBlockedQueryHandler(UserManager<UserAccount> userManager, IHttpContextAccessor contextAccestor)
        {
            _userManager = userManager;
            _contextAccestor = contextAccestor;
        }

        public async Task<IAppResponseDto> Handle(IsBlockedDto request, CancellationToken cancellationToken)
        {
            var logginUserId = _contextAccestor.HttpContext.GetLoginUserId();

            return new AppGenericSuccessResponseDto<bool>(
                await _userManager
                .Users
                .AnyAsync(
                    x =>
                        x.Id == logginUserId &&
                        x.UsersTheEntiyBlocked.Any(x => x.BlockedId == request.UserId),
                    cancellationToken
                )
            );

        }
    }
}
