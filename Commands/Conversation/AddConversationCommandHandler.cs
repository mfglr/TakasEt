using Application.Dtos;
using Application.Dtos.Conversation;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
	public class AddConversationCommandHandler : IRequestHandler<AddConversationDto, AppResponseDto>
	{
		private readonly IRepository<Conversation> _conversations;

		public AddConversationCommandHandler(IRepository<Conversation> conversations)
		{
			_conversations = conversations;
		}

		public async Task<AppResponseDto> Handle(AddConversationDto request, CancellationToken cancellationToken)
		{
			var conversation = new Conversation(request.SenderId, request.ReceiverId, request.FirstMessageContent);
			await _conversations.DbSet.AddAsync(conversation);
			return AppResponseDto.Success();
		}

	}
}
