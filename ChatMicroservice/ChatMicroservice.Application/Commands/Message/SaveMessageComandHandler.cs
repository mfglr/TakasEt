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
	public class SaveMessageComandHandler : IRequestHandler<SaveMessageDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SaveMessageComandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<AppResponseDto> Handle(SaveMessageDto request, CancellationToken cancellationToken)
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
			
			if ( conversation == null)
			{
				conversation = new Conversation(request.SenderId, request.ReceiverId);
				message = conversation.AddMessage(request.SenderId, request.Content);
				await _context.Conversations.AddAsync(conversation, cancellationToken);
			}
            else
				message = conversation.AddMessage(request.SenderId, request.Content);

			var numberOfChanges = await _unitOfWork.CommitAsync(cancellationToken);
			if (numberOfChanges <= 0) throw new Exception("error");

			return AppResponseDto.Success(_mapper.Map<MessageResponseDto>(message));
		}
	}
}
