using MediatR;

namespace Models.Dtos
{
	public class AddCommentDto : IRequest<AppResponseDto>
	{
        public int? ParentId { get; private set; }
        public int? PostId { get; private set; }
		public int? UserId { get; private set; }
		public string? Content { get; private set; }

		public AddCommentDto(int? parentId,int? postId, int? userId, string? content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}
	}
}
