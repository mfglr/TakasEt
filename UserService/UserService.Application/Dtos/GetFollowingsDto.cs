using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace UserService.Application.Dtos
{
    public class GetFollowingsDto : IRequest<IAppResponseDto>, IPage<DateTime>
    {
        public int Take { get; private set; }
        public DateTime LastValue { get; private set; }
        public bool IsDescending { get;set; }

        public GetFollowingsDto(IQueryCollection collection)
        {
            Take = collection.ReadInt("take") ?? 20;
            LastValue = collection.ReadDateTime("lastValue") ?? DateTime.Now;
            IsDescending = collection.ReadBoolean("isDescending") ?? true;
        }
    }
}
