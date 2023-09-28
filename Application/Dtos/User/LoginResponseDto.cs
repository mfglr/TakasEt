namespace Application.Dtos
{
	public class LoginResponseDto
	{
        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
		public bool IsLogin { get; private set; }

		public LoginResponseDto(string accessToken, string refreshToken, Guid id, string userName, string email)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
			Id = id;
			UserName = userName;
			Email = email;
			IsLogin = true;
		}
	}
}
