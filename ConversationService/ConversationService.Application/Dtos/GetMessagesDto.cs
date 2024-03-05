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
            Take = collection.ReadInt("take") ?? 20;
            LastValue = collection.ReadDateTime("lastValue") ?? DateTime.Now;
            IsDescending = collection.ReadBoolean("isDescending") ?? true;
        }

    }
}
