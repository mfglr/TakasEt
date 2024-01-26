namespace Models.Dtos
{
    public class LoginResponseDto
    {
		public int UserId { get; set; }
		public string AccessToken { get;  set; }
        public DateTime ExpirationDateOfAccessToken { get; set; }
        public string RefreshToken { get; set; }
		public DateTime ExpirationDateOfRefreshToken { get; set; }
    }
}
