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
    public class IsBlockerQueryHandler : IRequestHandler<IsBlockerDto, IAppResponseDto>
    {

        private readonly UserManager<UserAccount> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;


        public IsBlockerQueryHandler(UserManager<UserAccount> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(IsBlockerDto request, CancellationToken cancellationToken)
        {

            var logginUserId = _contextAccessor.HttpContext.GetLoginUserId();

            return new AppGenericSuccessResponseDto<bool>(
                await _userManager
                .Users
                .AnyAsync(
                    x => 
                        x.Id == logginUserId && 
                        x.UsersWhoBlockedTheEntity.Any(x => x.BlockerId == request.UserId),
                    cancellationToken
                )
            );

        }
    }
}
