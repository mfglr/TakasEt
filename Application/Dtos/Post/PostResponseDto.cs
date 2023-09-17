using Application.Entities;

namespace Application.Dtos
{
	public class PostResponseDto : BaseResponseDto
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public int CountOfLikes { get; set; }
		public int CountOfViews { get; set; }
		public DateTime PublishedDate { get; private set; }
		public Guid CategoryId { get; private set; }


		public PostResponseDto(Guid userId, string title, string content, int countOfLikes, int countOfViews, DateTime publishedDate, Guid categoryId)
		{
			UserId = userId;
			Title = title;
			Content = content;
			CountOfLikes = countOfLikes;
			CountOfViews = countOfViews;
			PublishedDate = publishedDate;
			CategoryId = categoryId;
		}

	}
}
