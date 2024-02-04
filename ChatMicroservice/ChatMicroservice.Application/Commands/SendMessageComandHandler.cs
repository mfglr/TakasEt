using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.ConversationAggregate;
using ChatMicroservice.Domain.MessageEntity;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Commands
{
	public class SendMessageComandHandler : IRequestHandler<SendMessageDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public SendMessageComandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(SendMessageDto request, CancellationToken cancellationToken)
		{
			Message message;
			var conversation = await _context
				.Conversations
				.FirstOrDefaultAsync(
					x => (
						x.SenderId == request.SenderId && x.ReceiverId == request.ReceiverId ||
						x.SenderId == request.ReceiverId && x.ReceiverId == request.SenderId
					)
				);
			
			if ( conversation == null )
				conversation = new Conversation(request.SenderId, request.ReceiverId);
			
			message = conversation.AddMessage(request.SenderId, request.Content);
			await _context.Conversations.AddAsync(conversation, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return AppResponseDto.Success(_mapper.Map<MessageResponseDto>(message));
		}
	}
}
