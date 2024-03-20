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
    public class MarkMessageAsReceivedCommandHandler : IRequestHandler<MarkMessageAsReceivedDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;


        public MarkMessageAsReceivedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(MarkMessageAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            await MessageAsReceivedAsync(request, loginUserId, cancellationToken);
        }

        private async Task MessageAsReceivedAsync(
            MarkMessageAsReceivedDto request, Guid loginUserId, CancellationToken cancellationToken
            )
        {
            var message = await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId, cancellationToken);

            if (message == null)
                throw new AppException("The message was not found!", HttpStatusCode.NotFound);
            
            message.MarkAsReceived(loginUserId, request.ReceivedDate);
            
            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch(DbUpdateConcurrencyException)
            {
                _context.ChangeTracker.Clear();
                message.ClearAllDomainEvents();
                await MessageAsReceivedAsync(request, loginUserId, cancellationToken);
            }
        }

    }
}
