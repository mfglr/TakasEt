using Models.Interfaces.Services;
using Models.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using Models.Configurations;
using Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class TokenService : ITokenService
	{
		private readonly Configuration _configuration;
		private readonly JwtSecurityTokenHandler _jwtHandler;

		public TokenService(Configuration configuration, JwtSecurityTokenHandler jwtHandler)
		{
			_configuration = configuration;
			_jwtHandler = jwtHandler;
		}

		private IEnumerable<Claim> GetClaimsByUser(User user, List<String> audiences)
		{

			var data = new Claim(ClaimTypes.Role, string.Join(",",user.Roles.Select(x => x.Role.Name)));
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Role, string.Join(",",user.Roles.Select(x => x.Role.Name)))
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

		public Token CreateRefreshToken()
		{
			var byteArray = new byte[32];
			using var randomValue = RandomNumberGenerator.Create();
			randomValue.GetBytes(byteArray);
			return new Token(Convert.ToBase64String(byteArray),DateTime.Now.AddMinutes(_configuration.CustomTokenOptions.ExprationOfRefreshToken));
		}
		
		public Token CreateAccessTokenByClient(Client client)
		{
			var expirationOfAccessToken = DateTime.Now.AddMinutes(_configuration.CustomTokenOptions.ExprationOfAccessToken);
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.CustomTokenOptions.SecurityKey));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _configuration.CustomTokenOptions.Issuer,
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
			var expirationOfAccessToken = DateTime.Now.AddMinutes(_configuration.CustomTokenOptions.ExprationOfAccessToken);
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.CustomTokenOptions.SecurityKey));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _configuration.CustomTokenOptions.Issuer,
				expires: expirationOfAccessToken,
				notBefore: DateTime.Now,
				claims: GetClaimsByUser(user, _configuration.CustomTokenOptions.Audiences),
				signingCredentials: signingCredentials
			);
			var token = _jwtHandler.WriteToken(jwtSecurityToken);
			return new Token(token, expirationOfAccessToken);
		}
	}
}
