using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class DisconnectCommandHandler : IRequestHandler<DisconnectDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DisconnectCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DisconnectDto request, CancellationToken cancellationToken)
        {

            Guid logginUserid = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var connection = await _context.UserConnections.FindAsync(logginUserid, cancellationToken);
            if (connection != null)
            {
                connection.Disconnect();
                await _unitOfWork.CommitAsync(cancellationToken);
            }
        }
    }
}
