using MediatR;
using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class GetUserByIdDto : IRequest<IAppResponseDto>
    {
        public Guid UserId { get; set; }
    }
}
