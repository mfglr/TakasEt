using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class UserImageResponseDto : ImageResponDto
    {
        public bool IsActive { get; set; }
    }
}
