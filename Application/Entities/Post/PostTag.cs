namespace Application.Entities
{
	public class PostTag : CrossEntity
	{
        public int PostId { get; private set; }
        public int TagId { get; private set; }

		public Post Post { get; }
		public Tag Tag { get; }

		public override int[] GetKey()
		{
			return new[] { PostId,TagId };
		}

		public PostTag(int postId, int tagId)
		{
			PostId = postId;
			TagId = tagId;
		}

	}
}
