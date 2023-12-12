namespace Application.Entities
{
	public class SwappingComment : Entity
	{
		public int SwappingCommentContentId { get; private set; }
        public SwappingCommentContent SwappingCommentContent { get; }
		public int SwappingId { get; private set; }
		public Swapping Swapping { get; }

		public SwappingComment(int swappingCommentContentId)
		{
			SwappingCommentContentId = swappingCommentContentId;
		}

	}
}
