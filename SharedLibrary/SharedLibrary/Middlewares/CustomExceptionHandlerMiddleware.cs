using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;

namespace SharedLibrary.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        private JsonSerializerSettings _settings;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, JsonSerializerSettings settings)
        {
            _next = next;
            _settings = settings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await context.WriteExceptionAsync(ex, _settings);
            }
        }

    }
}
