using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
	public class MakeRequestToJoinGroupCommandHandler : IRequestHandler<MakeRequestToJoinGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public MakeRequestToJoinGroupCommandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(MakeRequestToJoinGroupDto request, CancellationToken cancellationToken)
		{
			var group = await _context
				.Groups
				.Include(x => x.Users)
				.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);

			if (group == null) throw new Exception("error");
			
			group.MakeRequestToJoin(request.UserId);

			var numberOfChanges = await _unitOfWork.CommitAsync(cancellationToken);
			if (numberOfChanges <= 0) throw new Exception("error");

			return AppResponseDto.Success();

		}
	}
}
