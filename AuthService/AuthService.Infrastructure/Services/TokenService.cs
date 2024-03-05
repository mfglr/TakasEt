using AuthService.Core.Abstracts;
using AuthService.Core.Configurations;
using AuthService.Core.Entities;
using AuthService.Core.ValueObjects;
using AuthService.Infrastructure.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Exceptions;
using SharedLibrary.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace AuthService.Infrastructure.Services
{
    public class TokenService : ITokenService
    {

        private readonly ITokenProviderOptions _tokenConfiguration;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;


        public TokenService(ITokenProviderOptions tokenConfiguration, SigningCredentials signingCredentials, JwtSecurityTokenHandler jwtSecurityTokenHandler, UserManager<UserAccount> userManager)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingCredentials = signingCredentials;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _userManager = userManager;
        }

        private IEnumerable<Claim> GetClaims(UserAccount user,List<string> roles)
        {

            var countOfBlocking = user.UsersWhoBlockedTheEntity.Count() + user.UsersTheEntiyBlocked.Count();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(CustomClaimTypes.ProfileVisibility.Value,(!user.IsPrivateAccount).ToString()),
                new Claim(CustomClaimTypes.CountOfBlocking.Value,countOfBlocking.ToString()),
            };

            foreach(var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            claims.AddRange(
                _tokenConfiguration
                    .Audiences
                    .Select(
                        auidence => new Claim(JwtRegisteredClaimNames.Aud, auidence)
                    )
            );

            if (countOfBlocking <= 10)
            {
                foreach (var blocker in user.UsersWhoBlockedTheEntity)
                    claims.Add(new Claim(CustomClaimTypes.BlockerUser.Value, blocker.BlockerId));
                foreach (var blocked in user.UsersTheEntiyBlocked)
                    claims.Add(new Claim(CustomClaimTypes.BlockedUser.Value, blocked.BlockedId));
            }
            
            return claims;
        }

        public async Task<Token> CreateRefreshTokenAsync(string userId)
        {

            var expirationDate = DateTime.Now.AddMinutes(_tokenConfiguration.RefreshTokenExpiration);
            var user = 
                await _userManager.FindByIdAsync(userId) ??
                throw new AppException("User not found!", HttpStatusCode.NotFound);

            // update security stamp to revoke previous refresh token.
            var result = await _userManager.UpdateSecurityStampAsync(user);
            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.InternalServerError);

            var token = await _userManager
                .GenerateUserTokenAsync(
                    user,
                    TokenProvider.RefreshTokenProvider.Name,
                    "RefreshToken"
                );

            if (string.IsNullOrEmpty(token))
                throw new AppException(
                    "There are some issues, When creating refresh token!",
                    HttpStatusCode.InternalServerError
                );
            return new Token(expirationDate, token);
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

        public async Task<Token> CreateAccessTokenAsync(string userId)
        {
            var expirationDate = DateTime.Now.AddMinutes(_tokenConfiguration.AccessTokenExpiration);
            var user = await _userManager
                .Users
                .Include(x => x.UsersWhoBlockedTheEntity)
                .Include(x => x.UsersTheEntiyBlocked)
                .FirstOrDefaultAsync(x => x.Id == userId) ?? 
                throw new AppException("User not found!", HttpStatusCode.NotFound);

            var roles = (await _userManager.GetRolesAsync(user)).ToList();

            JwtSecurityToken jwtSecurityToken = new (
                issuer : _tokenConfiguration.Issuer,
                expires : expirationDate,
                notBefore : DateTime.Now,
                claims : GetClaims(user,roles),
                signingCredentials : _signingCredentials
            );
            string token;
            try
            {
                token = _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            }
            catch (Exception)
            {
                throw new AppException(
                    "There are some issues, When creating access token!",
                    HttpStatusCode.InternalServerError
                );
            }
            return new (expirationDate,token);
        }
        
    }
}
