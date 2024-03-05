using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Net;

namespace ConversationService.Application.Commands
{
    public class SendMessageViewedNotificationCommandHandler : IRequestHandler<SendMessageViewedNotificationDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BlockingService _blockingChecker;

        public SendMessageViewedNotificationCommandHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork, IMapper mapper, BlockingService blockingChecker)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blockingChecker = blockingChecker;
        }

        public async Task<IAppResponseDto> Handle(SendMessageViewedNotificationDto request, CancellationToken cancellationToken)
        {
            var receiverId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversation = await _context
                .Conversations
                .Include(x => x.Messages.Where(x => x.Id == request.MessageId))
                .FirstOrDefaultAsync(x => x.Id == request.ConversationId, cancellationToken);

            if (conversation == null)
                throw new AppException("The conversation was not found!", HttpStatusCode.NotFound);
            
            await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(conversation.SenderId.ToString());

            var message = conversation.ChangeMessageStateToViewed(receiverId, request.MessageId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
            );

        }
    }
}
