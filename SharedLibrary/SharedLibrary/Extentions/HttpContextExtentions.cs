using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.ValueObjects;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace SharedLibrary.Extentions
{
    public static class HttpContextExtentions
    {
        public static async Task WriteAppExceptionAsync(this HttpContext context, AppException ex)
        {
            var body = Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(new AppFailResponseDto(ex.Message))
            );
            context.Response.StatusCode = (int)ex.StatusCode;
            await context.Response.Body.WriteAsync(body, 0, body.Length);
        }

        public static async Task WriteExceptionAsync(this HttpContext context, Exception ex)
        {
            var body = Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(new AppFailResponseDto(ex.Message))
            );
            await context.Response.Body.WriteAsync(body, 0, body.Length);
        }


        public static int? GetInt(this HttpContext context,string type)
        {
            var claim = context.User.Claims.FirstOrDefault(x => x.Type == type);
            if(claim == null) return null;
            int value;
            try
            {
                value = int.Parse(claim.Value);
            }catch(Exception) {
                throw new AppException("eror", HttpStatusCode.InternalServerError);
            }
            return value;
        }

        public static bool IsVisibleAccout(this HttpContext context)
        {
            string? value = context.User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.ProfileVisibility.Value)?.Value;
            bool r;
            try { r = bool.Parse(value); } catch (Exception) { return false; }
            return r;
        }

        public static string? GetLoginUserId(this HttpContext context)
        {
            return context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public static List<string> GetListString(this HttpContext context,string claimType)
        {
            var values = context
                .User
                .Claims
                .Where(x => x.Type == claimType)
                .Select(x => x.Value)
                .ToList();
            return values;
        }

        public static string? GetAccessToken(this HttpContext context)
        {
            var pair = context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization");
            return pair.Value;
        }

    }
}
