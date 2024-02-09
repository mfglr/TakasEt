using ChatMicroservice.Application.Dtos.Group;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
    internal class RemoveUserFromGroupCommandHandler : IRequestHandler<RemoveUserFromGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		public RemoveUserFromGroupCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(RemoveUserFromGroupDto request, CancellationToken cancellationToken)
		{
			var group = await _context
				.Groups
				.Include(x => x.Users)
				.FirstOrDefaultAsync(x => x.Id == request.GrupId, cancellationToken);
			if (group == null) throw new Exception("Group is not found");
			group.RemoveUserPermanently(request.RemoverId, request.UserId);
			
			await _unitOfWork.CommitAsync(cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
