using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkMessagesAsReceivedCommandHandler : IRequestHandler<MarkMessagesAsReceivedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MarkMessagesAsReceivedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var ids = request.MessageItems.Select(x => x.Id).ToList();

            var messages = await _context
                .Messages
                .Where(x => ids.Contains(x.Id))
                .ToListAsync(cancellationToken);

            foreach(var message in messages)
                message.MarkAsReceived(
                    loginUserId, 
                    request.MessageItems.First(x => x.Id == message.Id).ReceivedDate.ToDateTime()
                );

            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppSuccessResponseDto();
        }
    }
}
