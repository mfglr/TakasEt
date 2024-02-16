using MediatR;
using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class FollowDto : IRequest<AppResponseDto>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
    }
}
