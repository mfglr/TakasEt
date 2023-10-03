using MediatR;

namespace Application.Dtos
{
	public class GetAppFileByKeyRequestDto : IRequest<byte[]>
	{
        public string BlobName { get; private set; }
        public string ContainerName { get; private set; }

		public GetAppFileByKeyRequestDto(string blobName, string containerName)
		{
			BlobName = blobName;
			ContainerName = containerName;
		}
	}
}
