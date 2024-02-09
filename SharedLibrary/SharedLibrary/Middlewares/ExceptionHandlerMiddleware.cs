using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Text;

namespace SharedLibrary.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        private JsonSerializerSettings _settings;

        public ExceptionHandlerMiddleware(RequestDelegate next, JsonSerializerSettings settings)
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
