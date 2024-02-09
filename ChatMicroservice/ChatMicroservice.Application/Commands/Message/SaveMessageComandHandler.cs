using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.ConversationAggregate;
using ChatMicroservice.Domain.MessageEntity;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.ValueObjects;

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

			if (request.ReceiverId != null)
			{
				var conversation = await _context
				.Conversations
				.FirstOrDefaultAsync(
					x => (
						x.SenderId == request.SenderId && x.ReceiverId == request.ReceiverId ||
						x.SenderId == request.ReceiverId && x.ReceiverId == request.SenderId
					)
				);

				if (conversation == null)
				{
					conversation = new Conversation(request.SenderId, (int)request.ReceiverId);
					message = conversation.AddMessage(request.SenderId, request.Content);
					await _context.Conversations.AddAsync(conversation, cancellationToken);
				}
				else
					message = conversation.AddMessage(request.SenderId, request.Content);
			}
			else if (request.GroupId != null)
			{
				var group = await _context
					.Groups
					.Include(x => x.Users)
					.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);
				if (group == null) throw new Exception("Group is not found!");
				message = group.AddMessage(request.SenderId, request.Content);
			}
			else
				throw new Exception("Either ReciverId or GroupId is required!");

			foreach (var image in request.MessageImages)
				message.AddImage(image.BlobName, image.Extention, new Dimension(image.Height, image.Width));

			await _unitOfWork.CommitAsync(cancellationToken);

			return AppResponseDto.Success(_mapper.Map<MessageResponseDto>(message));
		}
	}
}
