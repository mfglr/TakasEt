using MediatR;

namespace Models.Dtos
{
	public class GetGroupImageDto : IRequest<byte[]>
	{
        public string BlobName { get; set; }
		public GetGroupImageDto(string blobName) => BlobName = blobName;
	}
}
