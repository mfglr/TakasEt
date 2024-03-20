using ConversationService.Application.Dtos;
using ConversationService.Domain.UserConnectionAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class ConnectCommandHandler : IRequestHandler<ConnectDto>
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public ConnectCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(ConnectDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var connection = await _context.UserConnections.FindAsync(loginUserId, cancellationToken);
            
            if (connection == null)
            {
                connection = new UserConnection(loginUserId);
                connection.Connect(request.ConnectionId);
                await _context.UserConnections.AddAsync(connection,cancellationToken);
            }
            else
                connection.Connect(request.ConnectionId);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
