using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
	public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		public LeaveGroupCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(LeaveGroupDto request, CancellationToken cancellationToken)
		{
			var group = await _context
				.Groups
				.Include(x => x.Users)
				.FirstOrDefaultAsync(x => x.Id == request.GroupId,cancellationToken);

			if (group == null) throw new Exception("Group is not found!");
			group.Leave(request.UserId);
			
			await _unitOfWork.CommitAsync(cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
