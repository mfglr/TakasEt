using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Api.HubFilters
{
    public class SetHttpContextHubFilter : IHubFilter
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public SetHttpContextHubFilter(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async ValueTask<IAppResponseDto> InvokeMethodAsync(
       HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<IAppResponseDto>> next)
        {

            var httpContext = invocationContext.Context.GetHttpContext();
            if(httpContext == null)
                throw new AppException("HttpContext not found!",HttpStatusCode.InternalServerError);

            _contextAccessor.HttpContext = httpContext;

            return await next(invocationContext);
        }
    }
}
