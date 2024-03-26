using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Api.HubFilters
{
    public class ExceptionHubFilter : IHubFilter
    {

        public async ValueTask<IAppResponseDto> InvokeMethodAsync(
       HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<IAppResponseDto>> next)
        {
            try
            {
                return await next(invocationContext);
            }
            catch(AppException ex)
            {
                return new AppFailResponseDto(ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return new AppFailResponseDto(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

    }
}
