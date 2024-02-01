using MediatR;

namespace Models.Dtos
{
	public class GetUserImageDto : IRequest<byte[]>
	{
        public string BlobName { get; private set; }

		public GetUserImageDto(string blobName)
		{
			BlobName = blobName;
		}
	}
}
