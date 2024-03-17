using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;
using UserService.Infrastructure;

namespace UserService.Api.Filters
{
    public class UserNotFoundFilter : IAsyncActionFilter
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;

        public UserNotFoundFilter(IHttpContextAccessor contextAccessor, AppDbContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logginUserId = _contextAccessor.HttpContext.GetLoginUserId();
            if (logginUserId == null || !await _context.Users.AnyAsync(x => x.Id == Guid.Parse(logginUserId)))
                throw new AppException("Account not found!", HttpStatusCode.NotFound);
            await next();
        }
    }
}
