using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;

namespace SharedLibrary.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await context.WriteExceptionAsync(ex);
            }
        }

    }
}
