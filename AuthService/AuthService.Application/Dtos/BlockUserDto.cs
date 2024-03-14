using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class BlockUserDto : IRequest<IAppResponseDto>
    {
        public string UserId { get; set; }
        public string TimeZone { get; set; }
        public int Offset { get; set; }
    }
}
