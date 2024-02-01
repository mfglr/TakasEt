using Models.Interfaces.Repositories;
using Models.Interfaces.Services;
using MediatR;
using Models.Dtos;
using Models.Entities;
using Models.ValueObjects;

namespace Queries
{
	public class GetPostImageQueryHandler : IRequestHandler<GetPostImageDto, byte[]>
	{
		private readonly IBlobService _blobService;

		public GetPostImageQueryHandler(IBlobService blobService)
		{
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetPostImageDto request, CancellationToken cancellationToken)
		{
			return await _blobService.DownloadAsync(request!.BlobName, ContainerName.PostImage,cancellationToken);
		}
	}
}
