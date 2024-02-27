using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class UserResponseDto : BaseResponseDto<Guid>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? NormalizedFullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public bool IsFollower {  get; set; }
        public bool IsFollowing { get; set; }
        public IEnumerable<UserImageResponseDto> Images { get; set; }
    }
}
