using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class UploadFileCommandHandler : IRequestHandler<UploadFileDto, AppResponseDto<FileResponseDto>>
	{

		private readonly IBlobStorage _blobStorage;
		public UploadFileCommandHandler(IBlobStorage blobStorage)
		{
			_blobStorage = blobStorage;
		}
		public async Task<AppResponseDto<FileResponseDto>> Handle(UploadFileDto request, CancellationToken cancellationToken)
		{
			await _blobStorage.UploadAsync(
				request.File,
				request.BlobName,
				request.ContainerName
			);
			return AppResponseDto<FileResponseDto>.Success(
				new FileResponseDto(request.BlobName,request.ContainerName)
			);
		}
	}
}
