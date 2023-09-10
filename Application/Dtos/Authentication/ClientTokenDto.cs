namespace Application.Dtos
{
    public class ClientTokenDto
    {
        public string AccessToken { get; private set; }
        public DateTime ExpirationOfAccessToken { get; private set; }

        public ClientTokenDto(string accessToken, DateTime expirationOfAccessToken)
        {
            AccessToken = accessToken;
            ExpirationOfAccessToken = expirationOfAccessToken;
        }
    }
}
