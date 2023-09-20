using MediatR;

namespace Application.Dtos
{
	public class UploadFileRequestDto : IRequest<AppResponseDto>
	{
		public IReadOnlyCollection<Stream> Streams => _streams;
        public string ContainerName { get; private set; }
        public Guid OwnerId { get; private set; }
		public string Extentions { get; private set; }
        private readonly List<Stream> _streams = new List<Stream>();

		public UploadFileRequestDto(IEnumerable<Stream> streams , string containerName, Guid ownerId,string extentions)
		{
			if(streams != null)
				foreach(var stream in streams)
					_streams.Add(stream);
			ContainerName = containerName;
			OwnerId = ownerId;
			Extentions = extentions;
		}
	}
}
