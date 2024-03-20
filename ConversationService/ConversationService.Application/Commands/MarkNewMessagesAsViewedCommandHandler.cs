using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkNewMessagesAsViewedCommandHandler : IRequestHandler<MarkNewMessagesAsViewedDto, IAppResponseDto>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MarkNewMessagesAsViewedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkNewMessagesAsViewedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            return await MarkMessagesAsViewedAsync(request, loginUserId, cancellationToken);
        }

        private async Task<AppSuccessResponseDto> MarkMessagesAsViewedAsync(
            MarkNewMessagesAsViewedDto request,Guid userId, CancellationToken cancellationToken
            )
        {
            List<Message> messages;
            messages = await _context
                .Messages
                .Include(x => x.Sender)
                .Where(x => request.Ids.Contains(x.Id))
                .ToListAsync(cancellationToken);

            foreach (var message in messages)
                message.MarkAsViewed(userId, request.ViewedDate.ToDateTime());

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var message in messages)
                    message.ClearAllDomainEvents();
                _context.ChangeTracker.Clear();
                return await MarkMessagesAsViewedAsync(request, userId, cancellationToken);
            }
            return new AppSuccessResponseDto();
        }

    }
}
