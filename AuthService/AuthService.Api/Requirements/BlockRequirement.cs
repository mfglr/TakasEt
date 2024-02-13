using AuthService.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthService.Api.Requirements
{
    public class BlockRequirement : IAuthorizationRequirement
    {
    }

    public class BlockRequirementHandler : AuthorizationHandler<BlockRequirement>
    {

        private readonly DbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public BlockRequirementHandler(DbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BlockRequirement requirement)
        {
            var a = _contextAccessor.HttpContext;
            context.User.FindFirst(x => x.Type == ClaimTypes.Name);
            return Task.CompletedTask;
        }
    }

}
