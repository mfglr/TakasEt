using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.ConnectionAggregate;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
	public class ConnectCommandHandler : IRequestHandler<ConnectDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public ConnectCommandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(ConnectDto request, CancellationToken cancellationToken)
		{
			var connection = await _context
				.Connections
				.FirstOrDefaultAsync(x => x.UserId == request.UserId,cancellationToken);
			if (connection == null)
			{
				connection = new Connection(request.UserId, request.ConnectionId);
				await _context.Connections.AddAsync(connection,cancellationToken);
			}
			else
				connection.UpdateConnectionId(request.ConnectionId);
			connection.Connect();

			await _unitOfWork.CommitAsync(cancellationToken);

			return AppResponseDto.Success(_mapper.Map<ConnectionResponseDto>(connection));

		}
	}
}
