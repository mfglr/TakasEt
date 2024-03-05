using ConversationService.Application.Dtos;
using ConversationService.Application.Extentions;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Queries
{
    public class GetConversationsThatHaveNewMessagesQueryHandler : IRequestHandler<GetConversationsThatHaveNewMessagesDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetConversationsThatHaveNewMessagesQueryHandler(IHttpContextAccessor contextAccessor, AppDbContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<IAppResponseDto> Handle(GetConversationsThatHaveNewMessagesDto request, CancellationToken cancellationToken)
        {

            var logindUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversations = await _context
                .Conversations
                .Where(
                    x =>
                        (
                            x.ReceiverId == logindUserId || 
                            x.SenderId == logindUserId
                        ) &&
                        x.Messages.Any(m => m.State == MessageState.Saved)
                )
                .ToPage(x => x.DateTimeOfLastMessageReceived, request)
                .ToConversationResponseDto(logindUserId)
                .ToListAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(conversations);
        }
    }
}
