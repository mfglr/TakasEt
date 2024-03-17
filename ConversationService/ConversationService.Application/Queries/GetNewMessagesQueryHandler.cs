using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Queries
{
    public class GetNewMessagesQueryHandler : IRequestHandler<GetNewMessagesDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetNewMessagesQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(GetNewMessagesDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var messages = await _context
                .Messages
                .Where(x => x.ReceiverId == loginUserId && x.MessageState.Status != MessageState.Viewed.Status)
                .OrderBy(x => x.SendDate)
                .ToListAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<List<MessageResponseDto>>(
                    _mapper.Map<List<MessageResponseDto>>(messages)
                );
    
        }
    }
}
