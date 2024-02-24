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
    public class IsBlockerOrBlockedQueryHandler : IRequestHandler<IsBlockerOrBlockedDto, IAppResponseDto>
    {

        private readonly UserManager<UserAccount> _userManager;
        private readonly IHttpContextAccessor _contextAccesstor;

        public IsBlockerOrBlockedQueryHandler(UserManager<UserAccount> userManager, IHttpContextAccessor contextAccestor)
        {
            _userManager = userManager;
            _contextAccesstor = contextAccestor;
        }

        public async Task<IAppResponseDto> Handle(IsBlockerOrBlockedDto request, CancellationToken cancellationToken)
        {

            var logginUserId = _contextAccesstor.HttpContext.GetLoginUserId();

            return new AppGenericSuccessResponseDto<List<bool>>(
                new()
                {
                    await _userManager
                        .Users
                        .AnyAsync(
                            x =>
                                x.Id == logginUserId &&
                                x.UsersWhoBlockedTheEntity.Any(x => x.BlockerId == request.UserId),
                            cancellationToken
                        ),
                    await _userManager
                        .Users
                        .AnyAsync(
                            x =>
                                x.Id == logginUserId &&
                                x.UsersTheEntiyBlocked.Any(x => x.BlockedId == request.UserId),
                            cancellationToken
                        )
                }
            );

        }
    }
}
