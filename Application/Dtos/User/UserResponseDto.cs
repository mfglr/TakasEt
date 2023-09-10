namespace Application.Dtos
{
	public class UserResponseDto : BaseResponseDto
	{
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
    }
}
