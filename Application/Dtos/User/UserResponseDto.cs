namespace Application.Dtos
{
	public class UserResponseDto : BaseResponseDto
	{
		public string UserName { get;  set; }
        public string Email { get;  set; }
		public string? Name { get; set; }
		public string? LastName { get; set; }
		public int CountOfFolloweds { get; set; }
		public int CountOfFollowers { get; set; }
    }
}
