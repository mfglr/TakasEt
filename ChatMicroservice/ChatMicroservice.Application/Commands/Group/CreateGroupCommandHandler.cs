using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.GroupAggregate;
using ChatMicroservice.Infrastructure;
using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
	public class CreateGroupCommandHandler : IRequestHandler<CreateGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateGroupCommandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(CreateGroupDto request, CancellationToken cancellationToken)
		{
			var group = new Group(request.Name, request.Description);
			foreach (var userId in request.Users) group.AddUser(userId);

			await _context.Groups.AddAsync(group, cancellationToken);

			var numberOfChanges = await _unitOfWork.CommitAsync(cancellationToken);
			if (numberOfChanges <= 0) throw new Exception("error");

			return AppResponseDto.Success(_mapper.Map<GroupResponseDto>(group));
		}
	}
}
