using MediatR;

namespace Application.Dtos
{
	public class UploadFileRequestDto : IRequest<AppResponseDto>
	{
		public IReadOnlyCollection<Stream> Streams => _streams;
        public Guid OwnerId { get; private set; }
		public string Extention { get; private set; }
		
		private readonly List<Stream> _streams = new List<Stream>();

		public UploadFileRequestDto(IEnumerable<Stream> streams ,Guid ownerId,string extention)
		{
			if(streams != null)
				foreach(var stream in streams)
					_streams.Add(stream);
			OwnerId = ownerId;
			Extention = extention;
		}
	}
}
