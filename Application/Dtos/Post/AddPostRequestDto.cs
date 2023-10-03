using HttpMultipartParser;
using MediatR;

namespace Application.Dtos
{
	public class AddPostRequestDto : IRequest<AppResponseDto>
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public Guid CategoryId { get; private set; }
		public IReadOnlyCollection<Stream> Streams { get; private set; }
		public string Extentions { get; private set; }
        
		public AddPostRequestDto(MultipartFormDataParser parser)
		{
			Streams = parser.Files.Select(x => x.Data).ToList();
			Extentions = parser.GetParameterValue("extentions");
			UserId = Guid.Parse( parser.GetParameterValue("userId") ); 
			Title = parser.GetParameterValue("title");
			Content = parser.GetParameterValue("content");
			CategoryId = Guid.Parse( parser.GetParameterValue("categoryId"));
		}
	}
}
