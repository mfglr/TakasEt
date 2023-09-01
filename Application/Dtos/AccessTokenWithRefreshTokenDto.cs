using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
	public class AccessTokenWithRefreshTokenDto
	{
		public string AccessToken { get; private set; }
		public DateTime ExpirationOfAccessToken { get; private set; }
		public string RefreshToken { get; private set; }
		public DateTime ExpirationOfRefreshToken { get; private set; }

		public AccessTokenWithRefreshTokenDto(string accessToken, DateTime expirationOfAccessToken, string refreshToken, DateTime expirationOfRefreshToken)
		{
			AccessToken = accessToken;
			ExpirationOfAccessToken = expirationOfAccessToken;
			RefreshToken = refreshToken;
			ExpirationOfRefreshToken = expirationOfRefreshToken;
		}
	}
}
