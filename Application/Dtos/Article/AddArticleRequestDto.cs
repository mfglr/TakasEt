using MediatR;

namespace Application.Dtos
{
	public class AddArticleRequestDto : IRequest<AppResponseDto<AddArticleResponseDto>>
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string SumaryOfContent { get; private set; }
		public Guid CategoryId { get; private set; }

		public AddArticleRequestDto(Guid userId, string title, string content, string sumaryOfContent, DateTime publishedDate, Guid categoryId)
		{
			UserId = userId;
			Title = title;
			Content = content;
			SumaryOfContent = sumaryOfContent;
			CategoryId = categoryId;
		}
	}
}
