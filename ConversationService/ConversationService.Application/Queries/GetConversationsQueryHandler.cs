using ConversationService.Application.Dtos;
using ConversationService.Application.Extentions;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;

namespace ConversationService.Application.Queries
{
    public class GetConversationsQueryHandler : IRequestHandler<GetConversationsDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserService _userService;


        public GetConversationsQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, UserService userService)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<IAppResponseDto> Handle(GetConversationsDto request, CancellationToken cancellationToken)
        {

            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            
            var conversations = await _context
                .Conversations
                .Where(x => x.SenderId == loginUserId || x.ReceiverId == loginUserId)
                .ToPage(x => x.DateTimeOfLastMessageReceived, request)
                .ToConversationResponseDto(loginUserId)
                .ToListAsync(cancellationToken);

            var ids = conversations
                .Select(x => x.SenderId == loginUserId ? x.ReceiverId : x.SenderId)
                .ToList();

            var users = await _userService.GetUsersByIds(ids,cancellationToken);

            foreach ( var conversation in conversations)
                conversation.Receiver = users
                    .FirstOrDefault(
                        x => x.Id == conversation.ReceiverId || x.Id == conversation.SenderId 
                    );
            
            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(conversations);
    
        }
    }
}
