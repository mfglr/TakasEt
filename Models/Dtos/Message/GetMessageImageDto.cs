using MediatR;

namespace Models.Dtos
{
	public class GetMessageImageDto : IRequest<byte[]>
	{
		public string BlobName { get; set; }
		public GetMessageImageDto(string blobName) { BlobName = blobName; }
	}
}
