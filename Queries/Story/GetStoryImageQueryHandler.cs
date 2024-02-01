using MediatR;
using Models.Dtos;
using Models.Interfaces.Services;
using Models.ValueObjects;

namespace Queries
{
	public class GetStoryImageQueryHandler : IRequestHandler<GetStoryImageDto, byte[]>
	{
		private readonly IBlobService _blobService;

		public GetStoryImageQueryHandler(IBlobService blobService)
		{
			_blobService = blobService;
		}

		public Task<byte[]> Handle(GetStoryImageDto request, CancellationToken cancellationToken)
		{
			return _blobService.DownloadAsync(request.BlobName, ContainerName.StoryImage, cancellationToken);
		}
	}
}
