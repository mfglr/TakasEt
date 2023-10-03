using HttpMultipartParser;
using MediatR;

namespace Application.Dtos
{
	public class AddProfileImageRequestDto : IRequest<AppResponseDto>
	{
        public Guid	UserId { get; private set; }
        public string Extention { get; private set; }
        public Stream Stream { get; private set; }

		public AddProfileImageRequestDto(MultipartFormDataParser parser)
		{
			UserId = Guid.Parse(parser.GetParameterValue("userId"));
			Extention = parser.GetParameterValue("extention");
			Stream = parser.Files.Select(x => x.Data).First();
		}
	}
}
