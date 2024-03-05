using Microsoft.AspNetCore.Http;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace SharedLibrary.Services
{
    public class BlockingService
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AccountService _accountService;
        private readonly static int maxCountOfBlocking = 50;

        public BlockingService(IHttpContextAccessor contextAccesor, AccountService accountService)
        {
            _contextAccessor = contextAccesor;
            _accountService = accountService;
        }

        public async Task ThrowExceptionIfBlockerAsync(string userId)
        {
            var countOfBlocking = _contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if(countOfBlocking <= maxCountOfBlocking) {
                var blockerUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockerUser.Value);
                if (blockerUsers.Any(x => x == userId))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken();
                if (await _accountService.IsBlocker(userId, accessToken!))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }

        }
        public async Task ThrowExceptionIfBlockerAsync(HttpContext context, string userId)
        {
            var countOfBlocking = context.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if (countOfBlocking <= maxCountOfBlocking)
            {
                var blockerUsers = context.GetListString(CustomClaimTypes.BlockerUser.Value);
                if (blockerUsers.Any(x => x == userId))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }
            else
            {
                var accessToken = context.GetAccessToken();
                if (await _accountService.IsBlocker(userId, accessToken!))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
            }

        }
        public async Task ThrowExceptionIfBlockedAsync(string userId)
        {

            var countOfBlocking = _contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if( countOfBlocking <= maxCountOfBlocking)
            {
                var blockedUsers = _contextAccessor.HttpContext.GetListString(CustomClaimTypes.BlockedUser.Value);
                if (blockedUsers.Any(x => x == userId))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken();
                if (await _accountService.IsBlocked(userId, accessToken!))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            
        }
        public async Task ThrowExceptionIfBlockedAsync(HttpContext context, string userId)
        {

            var countOfBlocking = context.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if (countOfBlocking <= maxCountOfBlocking)
            {
                var blockedUsers = context.GetListString(CustomClaimTypes.BlockedUser.Value);
                if (blockedUsers.Any(x => x == userId))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            else
            {
                var accessToken = context.GetAccessToken();
                if (await _accountService.IsBlocked(userId, accessToken!))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }

        }
        public async Task ThrowExceptionIfBlockerOfBlockedAsync(string userId)
        {
            int countOfBlocking = (int)_contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value)!;
            if( countOfBlocking <= maxCountOfBlocking)
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
                var result = await _accountService.IsBlockerOrBlockedAsync(userId, accessToken!);

                if (result[0])
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
                if (result[1])
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
        }
        public async Task ThrowExceptionIfBlockerOfBlockedAsync(HttpContext context,string userId)
        {
            int countOfBlocking = (int)context.GetInt(CustomClaimTypes.CountOfBlocking.Value)!;
            if (countOfBlocking <= maxCountOfBlocking)
            {
                var blockerUsers = context.GetListString(CustomClaimTypes.BlockerUser.Value);
                if (blockerUsers.Any(x => x == userId))
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);

                var blockedUsers = context.GetListString(CustomClaimTypes.BlockedUser.Value);
                if (blockedUsers.Any(x => x == userId))
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
            else
            {
                var accessToken = context.GetAccessToken();
                var result = await _accountService.IsBlockerOrBlockedAsync(userId, accessToken!);

                if (result[0])
                    throw new AppException("User was not found!", HttpStatusCode.NotFound);
                if (result[1])
                    throw new AppException("You blocked the user.Before taking any action, you must remove the block.", HttpStatusCode.BadRequest);
            }
        }


        public async Task<List<Guid>> GetBlockers(CancellationToken cancellationToken = default)
        {
            var countOfBlocking = _contextAccessor.HttpContext.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if (countOfBlocking <= maxCountOfBlocking)
                return _contextAccessor.HttpContext.GetBlockers();
            else
            {
                var accessToken = _contextAccessor.HttpContext.GetAccessToken()!;
                return await _accountService.GetBlockers(accessToken,cancellationToken);
            }

        }
        public async Task<List<Guid>> GetBlockers(HttpContext context, CancellationToken cancellationToken = default)
        {
            var countOfBlocking = context.GetInt(CustomClaimTypes.CountOfBlocking.Value);

            if (countOfBlocking <= maxCountOfBlocking)
                return _contextAccessor.HttpContext.GetBlockers();
            else
            {
                var accessToken = context.GetAccessToken();
                if (accessToken == null)
                    throw new AppException("Token not found!", HttpStatusCode.BadRequest);
                return await _accountService.GetBlockers(accessToken!, cancellationToken);
            }

        }
    }
}
