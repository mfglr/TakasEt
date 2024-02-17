using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using AuthService.Core.ValueObjects;
using AuthService.Infrastructure.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.Exceptions;
using SharedLibrary.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace AuthService.Infrastructure.Services
{
    public class TokenService : ITokenService
    {

        private readonly ITokenConfiguration _tokenConfiguration;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public TokenService(ITokenConfiguration tokenConfiguration, SigningCredentials signingCredentials, JwtSecurityTokenHandler jwtSecurityTokenHandler, UserManager<UserAccount> userManager)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingCredentials = signingCredentials;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _userManager = userManager;
        }

        private IEnumerable<Claim> GetClaims(UserAccount user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, Role.User.Name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())//Token id
            };

            claims.AddRange(
                _tokenConfiguration
                    .Audiences
                    .Select(
                        auidence => new Claim(JwtRegisteredClaimNames.Aud, auidence)
                    )
            );
            return claims;
        }

        public async Task<string> CreateRefreshTokenAsync(UserAccount user)
        {

            // update security stamp to revoke previous refresh token.
            var result = await _userManager.UpdateSecurityStampAsync(user);
            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.InternalServerError);

            var refreshToken = await _userManager
                .GenerateUserTokenAsync(
                    user,
                    TokenProvider.RefreshTokenProvider.Name,
                    "RefreshToken"
                );

            if (string.IsNullOrEmpty(refreshToken))
                throw new AppException(
                    "There are some issues, When creating refresh token!",
                    HttpStatusCode.InternalServerError
                );
            return refreshToken;
        }

        public async Task<bool> VerifyRefreshTokenAsync(UserAccount user,string token)
        {
            return await _userManager
                .VerifyUserTokenAsync(
                    user,
                    TokenProvider.RefreshTokenProvider.Name,
                    "RefreshToken",
                    token
                );
        }

        public string CreateAccessToken(UserAccount user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer : _tokenConfiguration.Issuer,
                expires : DateTime.Now.AddMinutes(_tokenConfiguration.AccessTokenExpiration),
                notBefore : DateTime.Now,
                claims : GetClaims(user),
                signingCredentials : _signingCredentials
            );
            string token;
            try
            {
                token = _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            }
            catch ( Exception ex )
            {
                throw new AppException(
                    "There are some issues, When creating access token!",
                    HttpStatusCode.InternalServerError
                );
            }
            return token;
        }
        
    }
}
