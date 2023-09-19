using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class DownloadFileCommandHandler : IRequestHandler<DownloadFileRequestDto, AppResponseDto>
	{
		private readonly IBlobStorage _blobStorage;

		public DownloadFileCommandHandler(IBlobStorage blobStorage)
		{
			_blobStorage = blobStorage;
		}

		public async Task<AppResponseDto> Handle(DownloadFileRequestDto request, CancellationToken cancellationToken)
		{
			return AppResponseDto.Success(
				new DownloadFileResponseDto()
				{
					bytes = await _blobStorage.DownloadAsync(request.BlobName!, request.ContainerName!, cancellationToken)
				}
			);
		}
	}
}
