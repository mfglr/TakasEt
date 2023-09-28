using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class DownloadAppFileCommandHandler : IRequestHandler<DownloadFileRequestDto, AppResponseDto>
	{
		private readonly IAppFileService _blobStorage;

		public DownloadAppFileCommandHandler(IAppFileService blobStorage)
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
