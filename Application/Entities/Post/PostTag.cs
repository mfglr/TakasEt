namespace Application.Entities
{
	public class PostTag : Entity
	{
        public int PostId { get; private set; }
        public Post Post { get; }
        public int TagId { get; private set; }
        public Tag Tag { get; }

        public PostTag(int postId, int tagId)
		{
			PostId = postId;
			TagId = tagId;
		}

	}
}
