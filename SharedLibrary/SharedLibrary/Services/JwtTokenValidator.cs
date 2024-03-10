using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace SharedLibrary.Services
{
    public class JwtTokenValidator
    {
        private ClaimsPrincipal _principal;

        public void ValidateToken(string authToken, TokenValidationParameters parameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                _principal = tokenHandler.ValidateToken(authToken, parameters, out _);
            }
            catch (Exception)
            {
                throw new AppException("Invalid Token!", HttpStatusCode.Unauthorized);
            }
        }

    }
}
