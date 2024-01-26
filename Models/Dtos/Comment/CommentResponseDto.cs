﻿namespace Models.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public int? PostId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
		public string UserName { get; set; }
		public string Content { get; set; }
        public int CountOfChildren { get; set; }
		public int CountOfLikes { get; set; }
		public bool LikeStatus { get; set; }
		public UserImageResponseDto? UserImage { get; set; }
    }
}
