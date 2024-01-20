using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetConversationImageQueryHandler : IRequestHandler<GetConversationImageDto, byte[]>
	{
		private readonly IRepository<ConversationImage> _conversationImages;
		private readonly IBlobService _blobService;

		public GetConversationImageQueryHandler(IRepository<ConversationImage> conversationImages, IBlobService blobService)
		{
			_conversationImages = conversationImages;
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetConversationImageDto request, CancellationToken cancellationToken)
		{
			var image = await _conversationImages
				.DbSet
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			return await _blobService.DownloadAsync(image.BlobName, image.ContainerName, cancellationToken);
		}
	}
}
