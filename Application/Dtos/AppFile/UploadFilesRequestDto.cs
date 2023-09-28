using HttpMultipartParser;
using MediatR;

namespace Application.Dtos
{
	public class UploadFilesRequestDto : IRequest<AppResponseDto>
	{
		public IReadOnlyCollection<Stream> Streams { get; private set; }
        public string ContainerName { get; private set; }
        public Guid OwnerId { get; private set; }
		public string Extentions { get; private set; }


        public UploadFilesRequestDto(MultipartFormDataParser parser)
        {

			string ownerId = parser.GetParameterValue("ownerId");
			if(ownerId != null) OwnerId = Guid.Parse(ownerId);
			Streams = parser.Files.Select(x => x.Data).ToList();
			ContainerName = parser.GetParameterValue("containerName");
			Extentions = parser.GetParameterValue("extentions");
		}

		public void setOwnerId(Guid ownerId)
		{
			OwnerId = ownerId;
		}
	}
}
