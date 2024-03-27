using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;
using System.Net;

namespace ConversationService.Application.Commands
{
    public class MarkMessageAsViewedCommandHandler : IRequestHandler<MarkMessageAsViewedDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public MarkMessageAsViewedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(MarkMessageAsViewedDto request, CancellationToken cancellationToken)
        {

            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            await MessageViewedAsync(request, loginUserId, cancellationToken);
        }


        private async Task MessageViewedAsync(
            MarkMessageAsViewedDto request, Guid loginUserId, CancellationToken cancellationToken
            )
        {
            var message = await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId, cancellationToken);
            if (message == null)
                throw new AppException("The message was not found!", HttpStatusCode.NotFound);
            message.MarkAsViewed(loginUserId, request.ViewedDate.ToDateTime());

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.ChangeTracker.Clear();
                message.ClearAllDomainEvents();
                await MessageViewedAsync(request, loginUserId, cancellationToken);
            }
        }
    } 
}
