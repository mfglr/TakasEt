using MediatR;

namespace Application.Dtos
{
	public class AddComment : IRequest<AppResponseDto>
	{
        public int? ParentId { get; private set; }
        public int? PostId { get; private set; }
		public int UserId { get; private set; }
		public string Content { get; private set; }

		public AddComment(int? parentId,int? postId, int userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}
	}
}
