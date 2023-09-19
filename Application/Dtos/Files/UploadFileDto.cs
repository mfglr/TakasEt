using HttpMultipartParser;
using MediatR;

namespace Application.Dtos
{
	public class UploadFileDto : IRequest<AppResponseDto>
	{

		private readonly List<Stream> _streams = new List<Stream>();
		public IReadOnlyCollection<Stream> Streams { get; private set; }
        public string ContainerName { get; private set; }

        public UploadFileDto(IEnumerable<Stream> streams ,string containerName)
		{
			if(streams != null)
				_streams.ForEach(stream =>
				{
					_streams.Add(stream);
				});
			ContainerName = containerName;
		}

	}
}
