using MediatR;

namespace Application.Dtos
{
	public class AddPostRequestDto : IRequest<AppResponseDto>
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public Guid CategoryId { get; private set; }

		public AddPostRequestDto(Guid userId,string title, string content, Guid categoryId)
		{
			UserId = userId;
			Title = title;
			Content = content;
			CategoryId = categoryId;
		}
	}
}
