namespace Application.Dtos
{
	public class TokenDto
	{
        
		public string AccessToken { get; private set; }
        public DateTime ExpirationDateOfAccesToken { get; private set; }
        public string  RefreshToken { get; private set; }
        public DateTime ExprationDateOfRefreshToken { get; private set; }


		public TokenDto(string accessToken, DateTime expirationDateOfAccesToken, string refreshToken, DateTime exprationDateOfRefreshToken)
		{
			AccessToken = accessToken;
			ExpirationDateOfAccesToken = expirationDateOfAccesToken;
			RefreshToken = refreshToken;
			ExprationDateOfRefreshToken = exprationDateOfRefreshToken;
		}

	}
}
