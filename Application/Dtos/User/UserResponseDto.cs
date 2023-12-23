using Application.Dtos;

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
		public int CountOfPosts { get; set; }
		public bool IsFollowed { get; set; }
		public bool IsFollower { get; set; }
		public UserImageResponseDto? ProfileImage { get; set; }
    }
}
