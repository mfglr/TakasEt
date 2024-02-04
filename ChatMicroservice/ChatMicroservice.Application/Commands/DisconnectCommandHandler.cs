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
	public class DisconnectCommandHandler : IRequestHandler<DisconnectDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		public DisconnectCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(DisconnectDto request, CancellationToken cancellationToken)
		{
			var connection = await _context
				.Connections
				.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);
			
			if (connection != null) connection.Disconnect();
			
			await _unitOfWork.CommitAsync(cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
