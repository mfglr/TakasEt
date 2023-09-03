using MediatR;

namespace Application.Dtos
{
	public class AddCommentRequestDto : IRequest<AddCommentResponseDto>
	{
        public Guid? ParentId { get; private set; }
        public Guid ArticleId { get; private set; }
		public Guid UserId { get; private set; }
		public string Content { get; private set; }

		public AddCommentRequestDto(Guid parentId,Guid articleId, Guid userId, string content)
		{
			ParentId = parentId;
			ArticleId = articleId;
			UserId = userId;
			Content = content;
		}
	}
}
