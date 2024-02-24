using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
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

            var user = await _context
                .UserConnections
                .Include(x => x.IncomingConversations.Where(x => x.SenderId == loginUserId))
                .Include(x => x.OutgoingConversations.Where(x => x.ReceiverId == loginUserId))
                .Include(x => x.UsersWhoCanSendMessageToTheUser.Where(x => x.SenderId == loginUserId))
                .FirstOrDefaultAsync(x => x.Id == request.ReceiverId) ??
                throw new AppException("User was not found!", HttpStatusCode.NotFound);

            var message = user.SaveMessage(loginUserId, request.Content);
            await _unitOfWork.CommitAsync();

            return new AppGenericSuccessResponseDto<MessageResponseDto>(_mapper.Map<MessageResponseDto>(message));
        }
    }
}
