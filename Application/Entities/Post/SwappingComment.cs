namespace Application.Entities
{
	public class SwappingComment : Entity
	{
		public int Id { get; private set; }
		public int UserId { get; set; }
		public int SwappingCommentContentId { get; private set; }
		public int RequesterId { get; private set; }
		public int RequestedId { get; private set; }

		public User User { get; }
		public SwappingCommentContent SwappingCommentContent { get; private set; }
		public Swapping Swapping { get; }
		
		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public SwappingComment(int userId,int swappingCommentContentId)
		{
			UserId = userId;
			SwappingCommentContentId = swappingCommentContentId;
		}

		
	}
}
