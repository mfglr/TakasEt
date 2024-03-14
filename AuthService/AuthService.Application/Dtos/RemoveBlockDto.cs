using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class RemoveBlockDto : IRequest<IAppResponseDto>
    {
        public string BlockedId { get; set; }
        public string TimeZone { get; set; }
        public int Offset { get; set; }
    }
}
