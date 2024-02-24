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
    public class LikeMessageCommandHandler : IRequestHandler<LikeMessageDto, IAppResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingCheckerService _blockingChecker;

        public LikeMessageCommandHandler(AppDbContext context, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, BlockingCheckerService blockingChecker)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _blockingChecker = blockingChecker;
        }

        public async Task<IAppResponseDto> Handle(LikeMessageDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversation = await _context
                .Conversations
                .Include(x => x.Messages.Where(x => x.Id == request.MessageId))
                .FirstOrDefaultAsync(x => x.Id == request.ConversationId, cancellationToken);
            
            if (conversation == null)
                throw new AppException("The conversation was not found!", HttpStatusCode.NotFound);

            if(loginUserId == conversation.SenderId)
                await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(conversation.ReceiverId.ToString());
            else
                await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(conversation.SenderId.ToString());
            
            var message = conversation.LikeMessage(loginUserId,request.MessageId);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
            );
        }
    }
}
