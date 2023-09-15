using MediatR;

namespace Application.Dtos
{
	public class UploadFileDto : IRequest<AppResponseDto<FileResponseDto>>
	{

		public Stream File { get; private set; }
		public string BlobName { get; private set; }
        public string ContainerName { get; private set; }

        public UploadFileDto(Stream file, string blobName,string containerName)
		{
			File = file;
			BlobName = blobName;
			ContainerName = containerName;
		}
	}
}
