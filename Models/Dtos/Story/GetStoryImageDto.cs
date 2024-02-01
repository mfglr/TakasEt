using MediatR;

namespace Models.Dtos
{
	public class GetStoryImageDto : IRequest<byte[]>
	{
		public string BlobName { get; private set; }
        public GetStoryImageDto(string blobName)
        {
            BlobName = blobName;
        }
    }
}
