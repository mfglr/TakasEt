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
        public UploadFilesRequestDto UploadFiles { get; private set; }
        
		public AddPostRequestDto(MultipartFormDataParser parser)
		{
			UploadFiles = new UploadFilesRequestDto(parser);
			UserId = Guid.Parse( parser.GetParameterValue("userId") ); 
			Title = parser.GetParameterValue("title");
			Content = parser.GetParameterValue("content");
			CategoryId = Guid.Parse( parser.GetParameterValue("categoryId"));
		}
	}
}
