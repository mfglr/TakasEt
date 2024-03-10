using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Dtos
{
    public class GetConversationsDto : IRequest<IAppResponseDto>, IPage<DateTime>
    {
        public int Take { get; private set; }
        public DateTime LastValue { get; private set; }
        public bool IsDescending { get; private set; }

        public GetConversationsDto(IQueryCollection collections)
        {
            var lastValue = collections.ReadLong("lastValue");
            LastValue = lastValue != null ? ((long)lastValue!).ToDateTime() : DateTime.UtcNow;
            Take = collections.ReadInt("take") ?? 20;
            IsDescending = collections.ReadBoolean("isDescending") ?? true;
        }

    }
}
