using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace UserService.Application.Dtos
{
    public class GetUsersByIdsDto : IRequest<IAppResponseDto>
    {
        public List<Guid> Ids { get; set; }

        public GetUsersByIdsDto(IQueryCollection collection)
        {
            var ids = collection.ReadString("ids");
            if(ids == null)
                Ids = new List<Guid>();
            else
                Ids = ids.Split(',').Select(x => Guid.Parse(x)).ToList();
        }
    }
}
