using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Queries
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetMessagesQueryHandler(AppDbContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(GetMessagesDto request, CancellationToken cancellationToken)
        {

            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var messages = await _context
                .Messages
                .Where(
                    x => 
                        x.SenderId == loginUserId && x.ReceiverId == request.UserId ||
                        x.SenderId == request.UserId && x.ReceiverId == loginUserId
                )
                .ToPage(
                    x => loginUserId == x.SenderId ? x.SendDate : (DateTime)x.ReceivedDate!, 
                    x => x.SendDate,
                    request
                )
                .ToListAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<List<MessageResponseDto>>(
                _mapper.Map<List<MessageResponseDto>>(messages)
            );

        }
    }
}
