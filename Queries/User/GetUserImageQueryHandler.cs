using Models.Interfaces.Services;
using MediatR;
using Models.Dtos;
using Models.ValueObjects;

namespace Queries
{
	public class GetUserImageQueryHandler : IRequestHandler<GetUserImageDto, byte[]>
	{
		private readonly IBlobService _blobService;

		public GetUserImageQueryHandler(IBlobService blobService)
		{
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetUserImageDto request, CancellationToken cancellationToken)
		{
			return await _blobService.DownloadAsync(request.BlobName, ContainerName.UserImage, cancellationToken);
		}
	}
}
