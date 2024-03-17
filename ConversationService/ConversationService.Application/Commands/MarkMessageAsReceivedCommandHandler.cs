using AutoMapper;
using ConversationService.Application.Dtos;
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
    public class MarkMessageAsReceivedCommandHandler : IRequestHandler<MarkMessageAsReceivedDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;


        public MarkMessageAsReceivedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(MarkMessageAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            return await MessageAsReceivedAsync(request, loginUserId, cancellationToken);
        }

        private async Task<AppGenericSuccessResponseDto<MessageResponseDto>> MessageAsReceivedAsync(
            MarkMessageAsReceivedDto request, Guid loginUserId, CancellationToken cancellationToken
            )
        {
            _context.ChangeTracker.Clear();
            var message = await _context.Messages.FindAsync(request.MessageId, cancellationToken);
            if (message == null)
                throw new AppException("The message was not found!", HttpStatusCode.NotFound);
            message.MarkAsReceived(loginUserId, request.ReceivedDate);

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch(DbUpdateConcurrencyException)
            {
                return await MessageAsReceivedAsync(request, loginUserId, cancellationToken);
            }

            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
            );
        }

    }
}
