using Models.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Commands.message
{
	public class SaveMessageCommandHandler : IRequestHandler<SaveMessageDto, AppResponseDto>
	{
		private readonly IRepository<Conversation> _conversations;
		private readonly IMapper _mapper;

		public SaveMessageCommandHandler(IRepository<Conversation> conversations, IMapper mapper)
		{
			_conversations = conversations;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(SaveMessageDto request, CancellationToken cancellationToken)
		{

			Message message;
			
			var conversation = await _conversations
				.DbSet
				.Include(x => x.UsersWhoRemovedTheEntity)
				.FirstOrDefaultAsync(
					x => (
						x.SenderId == request.SenderId && x.ReceiverId == request.ReceiverId ||
						x.ReceiverId == request.SenderId && x.SenderId == request.ReceiverId
					),
					cancellationToken
				);
			
			if(conversation == null)
			{
				var newConversation = new Conversation((int)request.SenderId!, (int)request.ReceiverId!);
				message = newConversation.AddMessage((int)request.SenderId!,request.Content!);
				await _conversations.DbSet.AddAsync(newConversation,cancellationToken);
			}
			else
			{
				var IsRemoved = conversation.UsersWhoRemovedTheEntity.Any(x => x.RemoverId == request.SenderId);
				if(IsRemoved)
					conversation.AddAgainTheEntityToUser((int)request.SenderId!);
				message = conversation.AddMessage((int)request.SenderId!, request.Content!);
			}

			return AppResponseDto.Success(_mapper.Map<MessageResponseDto>(message));
		}
	}
}
