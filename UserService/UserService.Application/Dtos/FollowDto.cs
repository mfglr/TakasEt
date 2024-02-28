using MediatR;
using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class FollowDto : IRequest<IAppResponseDto>
    {
        public Guid UserId { get; set; }
    }
}
