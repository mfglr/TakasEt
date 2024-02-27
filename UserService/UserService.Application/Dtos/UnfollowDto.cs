using MediatR;
using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class UnfollowDto : IRequest<IAppResponseDto>
    {
        public Guid FollowingId { get; set; }
    }
}
