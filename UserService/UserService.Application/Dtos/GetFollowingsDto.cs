using MediatR;
using SharedLibrary.Dtos;

namespace UserService.Application.Dtos
{
    public class GetFollowingsDto : IRequest<IAppResponseDto>, IPage
    {
        public int? Take { get; set; }
        public DateTime? LastDate { get; set; }
    }
}
