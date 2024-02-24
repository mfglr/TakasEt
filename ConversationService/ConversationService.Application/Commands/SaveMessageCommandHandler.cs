using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingCheckerService _blockingChecker;


        public SaveMessageCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor, BlockingCheckerService blockingChecker)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _blockingChecker = blockingChecker;
        }

        public async Task<IAppResponseDto> Handle(SaveMessageDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(request.ReceiverId.ToString());

            var conversation = await _context
                .Conversations
                .FirstOrDefaultAsync(x => x.Id == request.ReceiverId);

            if(conversation == null)
                conversation = new Conversation(loginUserId, request.ReceiverId);

            var message = conversation.AddMessage(loginUserId, request.Content);
            await _unitOfWork.CommitAsync();

            return new AppGenericSuccessResponseDto<MessageResponseDto>(_mapper.Map<MessageResponseDto>(message));
        }
    }
}
