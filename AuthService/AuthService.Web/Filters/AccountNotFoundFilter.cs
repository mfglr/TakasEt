using AuthService.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;

namespace AuthService.Web.Filters
{
    public class AccountNotFoundFilter : IAsyncActionFilter
    {

        private readonly UserManager<UserAccount> _userManager;

        public AccountNotFoundFilter(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var userId = context.HttpContext.GetLoginUserId();
            if (
                userId == null ||
                (await _userManager.FindByIdAsync(userId)) == null
            )
                throw new AppException("The account was not found!", HttpStatusCode.NotFound);
            
            await next();

        }
    }
}
