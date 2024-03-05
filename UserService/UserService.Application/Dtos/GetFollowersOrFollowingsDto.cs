using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace UserService.Application.Dtos
{
    public class GetFollowersOrFollowingsDto : IRequest<IAppResponseDto>, IPage<string>
    {
        public int Take { get; private set; }
        public string LastValue { get; private set; }
        public bool IsDescending {get; private set; }

        public GetFollowersOrFollowingsDto(IQueryCollection collection)
        {
            Take = collection.ReadInt("take") ?? 20;
            LastValue = collection.ReadString("lastValue") ?? string.Empty;
            IsDescending = collection.ReadBoolean("isDescending") ?? true;
        }


    }
}
