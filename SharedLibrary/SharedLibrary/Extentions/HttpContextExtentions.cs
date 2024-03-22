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

        private static void ThrowExceptionIfContextIsNull(HttpContext? context)
        {
            if (context == null)
                throw new AppException("Context was not found!", HttpStatusCode.Unauthorized);
        }


        public static async Task WriteAppExceptionAsync(this HttpContext? context, AppException ex)
        {
            ThrowExceptionIfContextIsNull(context);

            var body = Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(new AppFailResponseDto(ex.Message,ex.StatusCode))
            );

            context!.Response.StatusCode = (int)ex.StatusCode;
            
            await context.Response.Body.WriteAsync(body, 0, body.Length);
        }

        public static async Task WriteExceptionAsync(this HttpContext? context, Exception ex)
        {
            ThrowExceptionIfContextIsNull(context);

            var body = Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(new AppFailResponseDto(ex.Message,HttpStatusCode.InternalServerError))
            );

            context!.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.Body.WriteAsync(body, 0, body.Length);
        }


        public static int? GetInt(this HttpContext? context,string type)
        {
            ThrowExceptionIfContextIsNull(context);

            var claim = context!.User.Claims.FirstOrDefault(x => x.Type == type);
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

        public static bool IsVisibleAccout(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            string? value = context!.User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.ProfileVisibility.Value)?.Value;
            bool r;
            try { r = bool.Parse(value); } catch (Exception) { return false; }
            return r;
        }
        
        public static string? GetLoginUserId(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            return context!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        public static string? GetUserName(this  HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            return context!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
        public static string? GetEmail(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            return context!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
        public static string? GetTimeZone(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            return context!.User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone.Value)?.Value;
        }
        public static int? GetOffset(this HttpContext context)
        {
            return GetInt(context,CustomClaimTypes.Offset.Value);
        }
        public static List<string> GetListString(this HttpContext? context,string claimType)
        {

            ThrowExceptionIfContextIsNull(context);

            var values = context!
                .User
                .Claims
                .Where(x => x.Type == claimType)
                .Select(x => x.Value)
                .ToList();
            return values;
        }

        public static string? GetAccessToken(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            var pair = context!.Request.Headers.FirstOrDefault(x => x.Key == "Authorization");
            return pair.Value;
        }

        public static List<Guid> GetBlockers(this HttpContext? context)
        {

            ThrowExceptionIfContextIsNull(context);

            return context!
                .User
                .Claims
                .Where(x => x.Type == CustomClaimTypes.BlockerUser.Value)
                .Select(x => Guid.Parse(x.Value))
                .ToList();
        }

        public static List<Guid> GetUsersBlocked(this HttpContext? context)
        {
            ThrowExceptionIfContextIsNull(context);

            return context!
                .User
                .Claims
                .Where(x => x.Type == CustomClaimTypes.BlockedUser.Value)
                .Select(x => Guid.Parse(x.Value))
                .ToList();
        }

    }
}
