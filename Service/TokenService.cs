using Application.Configurations;
using Application.Entities;
using Application.Interfaces.Services;
using Application.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Service
{
    public class TokenService : ITokenService
	{

		private readonly CustomTokenOptions _customTokenOptions;
		private readonly SignService _signService;
		private readonly JwtSecurityTokenHandler _jwtHandler;

		private IEnumerable<Claim> GetClaimsByUser(User user, List<String> audiences)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
			};
			claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
			return claims;
		}

		private IEnumerable<Claim> GetClaimsByClient(Client client)
		{
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Sub,client.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

			};
			claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
			return claims;
		}

		public TokenService(CustomTokenOptions customTokenOptions, SignService signService, JwtSecurityTokenHandler jwtHandler)
		{
			_customTokenOptions = customTokenOptions;
			_signService = signService;
			_jwtHandler = jwtHandler;
		}

		public Token CreateRefreshToken()
		{
			var byteArray = new byte[32];
			using var randomValue = RandomNumberGenerator.Create();
			randomValue.GetBytes(byteArray);
			return new Token(Convert.ToBase64String(byteArray),DateTime.Now);
		}
		
		public Token CreateAccessTokenByClient(Client client)
		{
			var expirationOfAccessToken = DateTime.Now.AddMinutes(_customTokenOptions.ExprationOfAccessToken);
			var securityKey = _signService.GetSymmetricSecurityKey(_customTokenOptions.SecurityKey);
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _customTokenOptions.Issuer,
				expires: expirationOfAccessToken,
				notBefore: DateTime.Now,
				claims: GetClaimsByClient(client),
				signingCredentials: signingCredentials
			);
			var token = _jwtHandler.WriteToken(jwtSecurityToken);
			return new Token(token, expirationOfAccessToken);
		}

		public Token CreateAccessTokenByUser(User user)
		{
			var expirationOfAccessToken = DateTime.Now.AddMinutes(_customTokenOptions.ExprationOfAccessToken);
			var securityKey = _signService.GetSymmetricSecurityKey(_customTokenOptions.SecurityKey);
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _customTokenOptions.Issuer,
				expires: expirationOfAccessToken,
				notBefore: DateTime.Now,
				claims: GetClaimsByUser(user, _customTokenOptions.Audiences),
				signingCredentials: signingCredentials
			);
			var token = _jwtHandler.WriteToken(jwtSecurityToken);
			return new Token(token, expirationOfAccessToken);
		}
	}
}
