﻿namespace Application.Entities
{
	public class SwappingComment : Entity
	{
		public int UserId { get; set; }
		public User User { get; }
		public int SwappingCommentContentId { get; private set; }
        public SwappingCommentContent SwappingCommentContent { get; private set; }
		public int SwappingId { get; private set; }
		public Swapping Swapping { get; }

		public SwappingComment(int userId,int swappingCommentContentId)
		{
			UserId = userId;
			SwappingCommentContentId = swappingCommentContentId;
		}
	}
}
