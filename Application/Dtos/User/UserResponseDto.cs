namespace Application.Dtos
{
	public class UserResponseDto : BaseResponseDto
	{
        public string UserName { get; private set; }
        public string Email { get; private set; }
    }
}
