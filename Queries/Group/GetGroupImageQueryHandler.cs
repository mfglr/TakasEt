using MediatR;
using Models.Dtos;
using Models.Interfaces.Services;
using Models.ValueObjects;

namespace Queries
{
	public class GetGroupImageQueryHandler : IRequestHandler<GetGroupImageDto, byte[]>
	{

		private readonly IBlobService _blobService;

		public GetGroupImageQueryHandler(IBlobService blobService)
		{
			_blobService = blobService;
		}

		public Task<byte[]> Handle(GetGroupImageDto request, CancellationToken cancellationToken)
		{

			return _blobService.DownloadAsync(request.BlobName, ContainerName.GroupImage, cancellationToken);
		}
	}
}
