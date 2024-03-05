using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.UserConnectionAggregate;
using ConversationService.Infrastructure;
using MediatR;
using SharedLibrary.Dtos;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class ConnectCommandHandler : IRequestHandler<ConnectDto, IAppResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConnectCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(ConnectDto request, CancellationToken cancellationToken)
        {
            var connection = await _context.UserConnections.FindAsync(request.LoginUserId,cancellationToken);
            if (connection == null)
            {
                connection = new UserConnection(request.LoginUserId);
                connection.Connect(request.ConnectionId);
                await _context.UserConnections.AddAsync(connection,cancellationToken);
            }
            else
                connection.Connect(request.ConnectionId);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<UserConnectionResponseDto>(
                _mapper.Map<UserConnectionResponseDto>(connection)
            );
        }
    }
}
