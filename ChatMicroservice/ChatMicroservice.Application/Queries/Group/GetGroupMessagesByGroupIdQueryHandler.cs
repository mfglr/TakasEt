using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ChatMicroservice.Application.Queries.Group
{
	public class GetGroupMessagesByGroupIdQueryHandler : IRequestHandler<GetGroupMessagesByGroupIdDto, AppResponseDto>
	{

		private readonly ChatDbContext _context;
		private readonly IMapper _mapper;

		public GetGroupMessagesByGroupIdQueryHandler(ChatDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetGroupMessagesByGroupIdDto request, CancellationToken cancellationToken)
		{
			var messages = await _context
				.Messages
				.AsNoTracking()
				.Where(
					x =>
						!x.IsRemoved &&
						!x.UsersWhoRemovedTheEntity.Any(x => x.UserId == request.UserId) &&
						x.GroupId == request.GroupId
				)
				.ToPage(request)
				.ToListAsync(cancellationToken);

			return AppResponseDto.Success(_mapper.Map<List<MessageResponseDto>>(messages));
				
		}
	}
}
