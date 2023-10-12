using MediatR;

namespace Application.Dtos
{
	public class GetAppFile : IRequest<byte[]>
	{
        public string BlobName { get; private set; }
        public string ContainerName { get; private set; }

		public GetAppFile(string blobName, string containerName)
		{
			BlobName = blobName;
			ContainerName = containerName;
		}
	}
}
