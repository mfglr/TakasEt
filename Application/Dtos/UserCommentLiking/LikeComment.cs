﻿using MediatR;

namespace Application.Dtos
{
	public class LikeComment : IRequest<AppResponseDto>
	{
        public int CommentId { get; private set; }
		public int LoggedInUserId { get; private set; }

		public LikeComment(int commentId, int loggedInUserId)
		{
			CommentId = commentId;
			LoggedInUserId = loggedInUserId;
		}
	}
}
