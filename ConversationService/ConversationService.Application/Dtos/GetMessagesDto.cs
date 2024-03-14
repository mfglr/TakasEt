using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Dtos
{
    public class GetMessagesDto : IRequest<IAppResponseDto>, IPage<DateTime>
    {
        public int Take { get; private set; }
        public DateTime LastValue { get; private set; }
        public bool IsDescending { get; private set; }
        public Guid UserId { get; set; }


        public GetMessagesDto(IQueryCollection collection)
        {
            var lastValue = collection.ReadLong("lastValue");
            Take = collection.ReadInt("take") ?? 20;
            LastValue = lastValue != null ? ((long)lastValue).ToDateTime() : default;
            IsDescending = collection.ReadBoolean("isDescending") ?? true;
        }

    }
}
