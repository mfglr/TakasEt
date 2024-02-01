using MediatR;

namespace Models.Dtos
{
	public class GetPostImageDto : IRequest<byte[]>
	{
		public string BlobName { get; set; }
		public GetPostImageDto(string blobName) { BlobName = blobName; }
    }
}
