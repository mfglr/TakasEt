namespace Models.Entities
{
    public class PostUserViewing : CrossEntity
    {
        public int UserId { get; private set; }
        public int PostId { get; private set; }

        public User User { get; }
        public Post Post { get; }

        public override int[] GetKey()
        {
            return new[] { UserId, PostId };
        }

        public PostUserViewing(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }
    }
}
