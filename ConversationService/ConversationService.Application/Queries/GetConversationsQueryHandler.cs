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
                .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
                .ToPage(x => x.DateTimeOfLastMessageReceived, request)
                .ToConversationResponseDto(loginUserId)
                .ToListAsync(cancellationToken);

            var ids = conversations
                .Select(x => x.UserId1 == loginUserId ? x.UserId2 : x.UserId1)
                .ToList();

            var users = await _userService.GetUsersByIds(ids,cancellationToken);

            foreach ( var conversation in conversations)
                conversation.Receiver = users
                    .FirstOrDefault(
                        x => x.Id == conversation.UserId1 || x.Id == conversation.UserId2
                    );
            
            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(conversations);
    
        }
    }
}
