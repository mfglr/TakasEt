using Microsoft.AspNetCore.Http;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace SharedLibrary.Services
{
    public class BlockingCheckerService
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserAccountService _userAccountService;

        public BlockingCheckerService(IHttpContextAccessor contextAccesor, UserAccountService userAccountService)
        {
            _contextAccessor = contextAccesor;
            _userAccountService = userAccountService;
        }

        public async Task ThrowExceptionIfBlockerAsync(string userId)
        {
            var countOfBlocking = _contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if(countOfBlocking <= 10) {
                var blockerUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockerUser.Value);
                if (blockerUsers.Any(x => x == userId))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken();
                if (await _userAccountService.IsBlocker(userId, accessToken!))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }

        }

        public async Task ThrowExceptionIfBlockedAsync(string userId)
        {

            var countOfBlocking = _contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if( countOfBlocking <= 10)
            {
                var blockedUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockedUser.Value);
                if (blockedUsers.Any(x => x == userId))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken();
                if (await _userAccountService.IsBlocked(userId, accessToken!))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            
        }

        public async Task ThrowExceptionIfBlockerOfBlockedAsync(string userId)
        {
            int countOfBlocking = (int)_contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value)!;
            if( countOfBlocking <= 10)
            {
                var blockerUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockerUser.Value);
                if (blockerUsers.Any(x => x == userId))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
                
                var blockedUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockedUser.Value);
                if (blockedUsers.Any(x => x == userId))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken();
                var result = await _userAccountService.IsBlockerOrBlockedAsync(userId, accessToken!);

                if (result[0])
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
                if (result[1])
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
        }

    }
}
