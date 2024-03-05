namespace SharedLibrary.Dtos
{
    public class UserResponseDto : BaseResponseDto<Guid>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public bool IsFollower {  get; set; }
        public bool IsFollowing { get; set; }
        public int CountOfFollowers { get; set; }
        public int CountOfFollowings { get; set; }
        public IEnumerable<UserImageResponseDto> Images { get; set; } = null!;
    }
}
