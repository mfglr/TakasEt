namespace AuthService.Application.Dtos
{
    public class LoginResponseDto
    {
        public string UserId { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public DateTime ExpirationDateOfAccessToken { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTime ExpirationDateOfRefreshToken{ get; set; }

    }
}
