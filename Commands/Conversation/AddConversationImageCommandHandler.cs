using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Commands
{
	public class AddConversationImageCommandHandler : IRequestHandler<AddConversationImageDto, AppResponseDto>
	{

		private readonly IRepository<Conversation> _conversations;
		private readonly IBlobService _blobService;

		public AddConversationImageCommandHandler(IRepository<Conversation> conversations, IBlobService blobService)
		{
			_conversations = conversations;
			_blobService = blobService;
		}

		public async Task<AppResponseDto> Handle(AddConversationImageDto request, CancellationToken cancellationToken)
		{
			var conversation = await _conversations
				.DbSet
				.FirstOrDefaultAsync(x => x.Id == request.ConversationId,cancellationToken);
			
			if (conversation == null) throw new ConversationNotFoundException();

			var blobName = CreateUniqFileName.RunHelper(request.Extention!);
			await _blobService.UploadAsync(request.Stream!,blobName,ContainerName.ConversationImage.Value,cancellationToken);
			conversation.AddConversationImage(blobName, request.Extention!);
			
			return AppResponseDto.Success();
		}
	}
}
