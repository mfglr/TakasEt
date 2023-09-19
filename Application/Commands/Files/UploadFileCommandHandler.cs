using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;


namespace Application.Commands
{
	public class UploadFileCommandHandler : IRequestHandler<UploadFileDto, AppResponseDto>
	{

		private readonly IBlobStorage _blobStorage;
		public UploadFileCommandHandler(IBlobStorage blobStorage)
		{
			_blobStorage = blobStorage;
		}
		public async Task<AppResponseDto> Handle(UploadFileDto request, CancellationToken cancellationToken)
		{
			foreach(var stream in  request.Streams)
				await _blobStorage.UploadAsync(stream,Guid.NewGuid().ToString(),request.ContainerName);
			return AppResponseDto.Success();
		}
	}
}
