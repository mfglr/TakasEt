namespace Application.Dtos.SignUp
{
	public class SignUpCommandResponseDto : BaseResponseDto
	{
		public SignUpCommandResponseDto(Guid id, DateTime createdDate, DateTime? updatedDate, string userName, string email) : base(id, createdDate, updatedDate)
		{
			UserName = userName;
			Email = email;
		}

		public string UserName { get; private set; }
		public string Email { get; private set; }

    }
}
