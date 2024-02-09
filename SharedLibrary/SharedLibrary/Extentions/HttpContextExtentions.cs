using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Text;

namespace SharedLibrary.Extentions
{
    public static class HttpContextExtentions
    {
        public static async Task WriteExceptionAsync(this HttpContext context, AppException ex,JsonSerializerSettings settings)
        {
            var body = Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(AppResponseDto.Fail(ex.Message),settings)
            );
            context.Response.StatusCode = (int)ex.StatusCode;
            await context.Response.Body.WriteAsync(body, 0, body.Length);
        }

    }
}
