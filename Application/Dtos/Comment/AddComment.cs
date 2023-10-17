using MediatR;

namespace Application.Dtos
{
	public class AddComment : IRequest<AppResponseDto>
	{
        public Guid? ParentId { get; private set; }
        public Guid? PostId { get; private set; }
		public Guid UserId { get; private set; }
		public string Content { get; private set; }

		public AddComment(Guid? parentId,Guid? postId, Guid userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}
	}
}
