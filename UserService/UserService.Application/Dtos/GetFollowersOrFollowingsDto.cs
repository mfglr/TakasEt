using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace UserService.Application.Dtos
{
    public class GetFollowersOrFollowingsDto : IRequest<IAppResponseDto>, IPage
    {
        public int? Take { get; set; }
        public DateTime? LastDate { get; set; }

        public GetFollowersOrFollowingsDto(IQueryCollection query)
        {
            Take = query.ReadInt("take");
            LastDate = query.ReadDateTime("lastDate");
        }

    }
}
