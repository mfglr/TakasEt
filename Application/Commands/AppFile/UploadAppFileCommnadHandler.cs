using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands.Files
{
	public class UploadAppFileCommnadHandler : IRequestHandler<UploadFilesRequestDto, AppResponseDto>
	{
		private readonly IAppFileService _fileStorage;

		public UploadAppFileCommnadHandler(IAppFileService fileStorage)
		{
			_fileStorage = fileStorage; 
		}
		
		public async Task<AppResponseDto> Handle(UploadFilesRequestDto request, CancellationToken cancellationToken)
		{
			await _fileStorage.UploadAsync(request, cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
