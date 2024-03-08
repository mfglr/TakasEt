using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;
using System.Net;

namespace ConversationService.Application.Commands
{
    public class MarkMessagesAsViewedCommandHandler : IRequestHandler<MarkMessagesAsViewedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MarkMessagesAsViewedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkMessagesAsViewedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversation = await _context
                .Conversations
                .Include(x => x.Messages.Where(
                    x =>
                        x.MessageState.Status != MessageState.Viewed.Status &&
                        x.SenderId != loginUserId
                ))
                .FirstOrDefaultAsync(
                    x => 
                        x.UserId1 == loginUserId && x.UserId2 == request.UserId ||
                        x.UserId1 == request.UserId && x.UserId2 == loginUserId
                );
            
            if(conversation == null)
                throw new AppException("Conversation not found!",HttpStatusCode.NotFound);
            
            conversation.MarkMessagesAsViewed(loginUserId,request.ViewedDate);

            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppSuccessResponseDto();
        }
    }
}
