using MediatR;

namespace Application.Dtos
{
	public class DownloadFileRequestDto : IRequest<AppResponseDto>
	{
        public string? BlobName { get; set; }
        public string? ContainerName { get; set; }
    }
}
