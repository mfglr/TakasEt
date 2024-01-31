using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;
using Models.Extentions;
using Models.Interfaces.Repositories;

namespace Queries
{
	public class GetConversationsQueryHandler : IRequestHandler<GetConversationsDto, AppResponseDto>
	{

		private readonly IRepository<Conversation> _conversations;
		private readonly IMapper _mapper;

		public GetConversationsQueryHandler(IRepository<Conversation> conversations, IMapper mapper)
		{
			_conversations = conversations;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetConversationsDto request, CancellationToken cancellationToken)
		{
			var conversations = await _conversations
				.DbSet
				.AsNoTracking()
				.Where(
					x => (
						x.SenderId == request.LoggedInUserId || 
						x.ReceiverId == request.LoggedInUserId
					)
				)
				.ToPage(request)
				.ToListAsync(cancellationToken);

			return AppResponseDto.Success(_mapper.Map<List<ConversationResponseDto>>(conversations));


		}
	}
}
