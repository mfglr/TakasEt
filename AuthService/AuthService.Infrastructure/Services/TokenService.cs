using AuthService.Core.Interfaces;
using AuthService.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthService.Infrastructure.Services
{
    public class TokenService : ITokenService
    {

        private readonly UserManager<User> _userManager;
        private readonly ITokenConfiguration _tokenConfiguration;
        private readonly ISignService _signService;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;


        public TokenService(UserManager<User> userManager, ITokenConfiguration tokenConfiguration, ISignService signService, SigningCredentials signingCredentials, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _userManager = userManager;
            _tokenConfiguration = tokenConfiguration;
            _signService = signService;
            _signingCredentials = signingCredentials;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        private IEnumerable<Claim> GetClaims(string userId, string userName)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
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

        public Token CreateRefreshToken()
        {
            var bytes = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(bytes);
            
            return new Token(
                Convert.ToBase64String(bytes),
                DateTime.Now.AddMinutes(_tokenConfiguration.RefreshTokenExpiration)
            );
        }

        public Token CreateAccessToken(string userId,string userName)
        {
            var expirationDateOfAccessToken = DateTime.Now.AddMinutes(_tokenConfiguration.AccessTokenExpiration);
            
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer : _tokenConfiguration.Issuer,
                expires : expirationDateOfAccessToken,
                notBefore : DateTime.Now,
                claims : GetClaims(userId, userName),
                signingCredentials : _signingCredentials
            );

            return new Token(
                _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken),
                expirationDateOfAccessToken
            );
        }
        
    }
}
