namespace Application.Dtos
{
	public class AccessTokenDto
	{
        public string AccessToken { get; private set; }
        public DateTime ExpirationOfAccessToken { get; private set; }

		public AccessTokenDto(string accessToken, DateTime expirationOfAccessToken)
		{
			AccessToken = accessToken;
			ExpirationOfAccessToken = expirationOfAccessToken;
		}
	}
}
