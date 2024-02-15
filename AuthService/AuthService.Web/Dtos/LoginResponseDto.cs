namespace AuthService.Web.Dtos
{
    internal class LoginResponseDto
    {
        public string UserId { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
