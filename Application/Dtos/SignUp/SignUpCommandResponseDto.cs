namespace Dto.SignUp
{
	public class SignUpCommandResponseDto : BaseResponseDto
	{
		public string UserName { get; private set; }
		public string? Email { get; private set; }
		public string? Phone { get; private set; }
	}
}
