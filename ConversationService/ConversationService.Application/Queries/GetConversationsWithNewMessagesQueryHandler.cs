using ConversationService.Application.Dtos;
using ConversationService.Application.Extentions;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;

namespace ConversationService.Application.Queries
{
    public class GetConversationsWithNewMessagesQueryHandler : IRequestHandler<GetConversationsWithNewMessagesDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserService _userService;


        public GetConversationsWithNewMessagesQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, UserService userService)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<IAppResponseDto> Handle(GetConversationsWithNewMessagesDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            
            var conversations = await _context
                .Conversations
                .Where(
                    x => 
                        (x.UserId1 == loginUserId || x.UserId2 == loginUserId) &&
                        x.Messages.Any(
                            x => 
                                x.MessageState.Status != MessageState.Viewed.Status &&
                                x.CreatedDate < request.TimeStamp
                        )
                )
                .OrderByDescending(x => x.DateTimeOfLastMessage)
                .ToConversationResponseDto(loginUserId)
                .ToListAsync(cancellationToken);

            if (conversations.Any())
            {
                var ids = conversations.Select(x => x.ReceiverId).ToList();
                List<UserResponseDto> users = await _userService.GetUsersByIds(ids, cancellationToken);

                foreach (var conversation in conversations)
                    conversation.Receiver = users.FirstOrDefault(x => x.Id == conversation.ReceiverId);
            }
            
            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(conversations);
    
        }
    }
}
