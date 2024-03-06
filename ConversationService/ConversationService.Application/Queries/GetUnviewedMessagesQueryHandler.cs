using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Queries
{
    public class GetUnviewedMessagesQueryHandler : IRequestHandler<GetUnviewedMessagesDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetUnviewedMessagesQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(GetUnviewedMessagesDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var messages = _context
                .Messages
                .Where(
                    x =>
                        (
                            x.SenderId == loginUserId && x.ReceiverId == request.UserId ||
                            x.SenderId == request.UserId && x.ReceiverId == loginUserId
                        ) &&
                        x.MessageState.Status != MessageState.Viewed.Status
                )
                .ToPage(x => x.CreatedDate, request)
                .ToListAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<List<MessageResponseDto>>(
                _mapper.Map<List<MessageResponseDto>>(messages)
            );
        }
    }
}
